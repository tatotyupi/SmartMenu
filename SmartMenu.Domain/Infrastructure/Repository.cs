using System;
using System.Collections.Generic;
using System.Text;

namespace MMenu.Domain.Infrastructure
{
    public interface Repository
    {
        TEntity Get<TEntity>(object entityKey)
          where TEntity : class;
        void Store(params Entity[] entities);
    }
}
