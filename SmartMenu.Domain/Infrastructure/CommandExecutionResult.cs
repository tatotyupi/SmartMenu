using System;
using System.Collections.Generic;
using System.Text;

namespace MMenu.Domain.Infrastructure
{
    public class CommandExecutionResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
