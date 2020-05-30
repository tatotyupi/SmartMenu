using MMenu.Domain.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartMenu.DbContext.Infrastructure
{
    public class Graff : IEnumerable<Entity>
    {
        private readonly Entity entity;
        private readonly IEnumerable<Type> tableNames;

        public Graff(Entity entity, IEnumerable<Type> tableNames)
        {
            this.entity = entity;
            this.tableNames = tableNames;
        }
        public IEnumerator<Entity> GetEnumerator()
        {
            var result = GetNext(entity, tableNames);
            var gr = result.GroupBy(e => new { e.Key, e.GetType().Name }).SelectMany(g => new List<Entity>() { g.First() }).GetEnumerator();
            return result.GetEnumerator();
        }
        private IEnumerable<Entity> GetNext(Entity entity, IEnumerable<Type> tableNames)
        {
            var entities = entity
                .GetType()
                .GetProperties()
                .Select(p =>
                {
                    var a = new
                    {
                        p,
                        isEnumerable = p
                            .PropertyType
                            .GetInterfaces()
                            .Any(i => i.IsAssignableFrom(typeof(IEnumerable))) && p.PropertyType != typeof(string),
                        isRecord = tableNames.Any(t => p.PropertyType.IsAssignableFrom(t))
                    };
                    return a;
                })
                .Where(pd => pd.isEnumerable || pd.isRecord)
                .Where(pd => pd.p.GetValue(entity, null) != null)
                .SelectMany(pd =>
                {
                    if (pd.isRecord)
                    {
                        return new List<Entity>() { (Entity)(pd.p.GetValue(entity, null)) };
                    }
                    else
                    {
                        var obj = (IEnumerable<Entity>)(pd.p.GetValue(entity, null));
                        return obj
                                .SelectMany(o => GetNext(o, tableNames));
                    }
                });
            return new List<Entity>() { entity }.Concat(entities);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
