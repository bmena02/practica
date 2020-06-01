using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSoluciones.Properties
{
    public class OperationResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public OperationResult(bool result)
        {
            this.Result = result;
        }

        public OperationResult(bool result, string message)
        {
            this.Result = result;
            this.Message = message;
        }
        public OperationResult(bool result, string message, object data)
        {
            this.Result = Result;
            this.Message = Message;
            this.Data = Data;
        }

        public OperationResult()
        {
        }
    }
}
