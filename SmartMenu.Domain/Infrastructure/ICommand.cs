using System;
using System.Collections.Generic;
using System.Text;

namespace MMenu.Domain.Infrastructure
{
    public interface ICommand<TEntity> : IMessage
    {
        public object EntityId();
    }
}
