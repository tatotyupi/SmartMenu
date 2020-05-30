using Microsoft.EntityFrameworkCore;
using MMenu.Domain.Infrastructure;
using Newtonsoft.Json;
using SmartMenu.DbContext;
using SmartMenu.DbContext.Infrastructure;
using System;
using System.Linq;
namespace MMenu.DbContext
{
    public class EntityRepository : Repository
    {
        private readonly Factory<SmartMenuDbContext> _dbContextFactory;

        public EntityRepository() { }

        public EntityRepository(Factory<SmartMenuDbContext> dbContext)
        {
            _dbContextFactory = dbContext;
        }

        public TEntity Get<TEntity>(object entityKey)
            where TEntity : class
        {
            {
                return JsonConvert
                    .DeserializeObject<TEntity>(
                    _dbContextFactory
                        .Make()
                        .Aggregates
                        .FirstOrDefault(a => a.EntityKey == entityKey.ToString() && a.Name == typeof(TEntity).Name)
                        .State
                    );
            }
        }
        public void Store(params Entity[] entities)
        {
            using var db = _dbContextFactory.Make();
            db.Database.OpenConnection();
            foreach (var item in entities)
            {
                Attach(db, item);
            }

            db.SaveChanges();
        }

        public void Attach(SmartMenuDbContext db, Entity entity)
        {

            var tableNames = db
                .Model
                .GetEntityTypes()
                .Select(t => t.ClrType).ToList();


            var entities = new Graff(entity, tableNames).ToList();
            var sql = entities
                .Aggregate(String.Empty, (p, e) =>
                {
                    e.Up();
                    return $"{p}{Environment.NewLine}UPDATE T SET T.[IsCurrent] = 0 FROM [{e.GetType().Name}] AS T WHERE [IsCurrent] = 1 AND [{e.KeyName}] = '{e.Key}'";
                });

            db
                .Database
                .ExecuteSqlRaw(sql);

            foreach (var en in entities)
            {
                en.Up();
                //TODO: add rootId on every entities under the aggregate root
                //en.RootId = entity.ID;
                db.Entry(en).State = EntityState.Added;
            }

            entity.Up();
            var currentAggregate = new Aggregate
            {
                EntityKey = entity.Key,
                Name = entity.GetType().Name,
                State = JsonConvert.SerializeObject(entity)
            };

            var prevAggregate = db.Aggregates.FirstOrDefault(a => a.EntityKey == entity.Key.ToString() && a.Name == entity.GetType().Name);
            if (prevAggregate == null)
            {
                db.Entry(currentAggregate).State = EntityState.Added;
            }
            else
            {
                prevAggregate.State = currentAggregate.State;
                db.Entry(prevAggregate).State = EntityState.Modified;
            }
        }
    }
}
