using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMenu.DbContext.Infrastructure
{
    public interface Factory<T>
    {
        T Make();
    }
}
