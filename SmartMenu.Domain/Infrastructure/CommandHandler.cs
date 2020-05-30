using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace MMenu.Domain.Infrastructure
{
    public interface CommandHandler<TEntity, in TMessage>
    {
        TEntity Handle(TEntity state, TMessage command);
    }


    public interface CommandsHandler<TEntity, TMessage>
        where TMessage : IMessage
        where TEntity : Entity
    {
        IEnumerable<Entity> Handle(TEntity entity, TMessage msg);
    }

    public class CommandHandlerWrapper<TEntity, TMessage> : CommandsHandler<TEntity, TMessage>
                where TMessage : IMessage
                where TEntity : Entity
    {
        private readonly CommandHandler<TEntity, TMessage> handler;

        public CommandHandlerWrapper(CommandHandler<TEntity, TMessage> handler)
        {
            this.handler = handler;
        }

        public IEnumerable<Entity> Handle(TEntity entity, TMessage msg)
        {
            return new List<Entity>()
            {
                handler.Handle(entity, msg)
            };
        }
    }

    public class Handler<TEntity, TMessage>
                where TMessage : ICommand<TEntity>
                where TEntity : Entity
    {
        private readonly CommandsHandler<TEntity, TMessage> commandHandlers;
        private readonly Repository repository;
        private readonly string role;

        public Handler(
            CommandsHandler<TEntity, TMessage> commandHandler,
            Repository repository
            )
            :this(
                 commandHandler, 
                 repository,
                 string.Empty
                 )
        {

        }
        public Handler(
            CommandHandler<TEntity, TMessage> commandHandler,
            Repository repository,
            string role

        )
            : this(new CommandHandlerWrapper<TEntity, TMessage>(commandHandler), repository, role)
        { }

        public Handler(
                    CommandsHandler<TEntity, TMessage> commandHandlers,
                    Repository repository,
                    string role
               )
        {
            this.commandHandlers = commandHandlers;
            this.repository = repository;
            this.role = role;
        }

        public CommandExecutionResult Handle(TEntity entity, TMessage command)
        {
            // var permission = new Permissions().Results().Any(x => x.Key.ToString() == role && x.Value.Any(v => v.ToString() == typeof(TMessage).Name));

            if (true)
            {
                var entities = commandHandlers.Handle(entity, command);

                using (var transition = new TransactionScope(TransactionScopeOption.Required, TimeSpan.MaxValue))
                {
                    entities.Select(entity =>
                    {
                        repository.Store(entity);
                        return true;
                    }).ToList();

                    transition.Complete();
                }
                return new CommandExecutionResult
                {
                    Success = true
                };
            }
            //return new CommandExecutionResult
            //{
            //    Success = false,
            //    Message = "Error"
            //};
        }
        public CommandExecutionResult Handle(TMessage command)
        {
            var aggregate = repository.Get<TEntity>(command.EntityId());
            return Handle(aggregate, command);
        }
    }
}
