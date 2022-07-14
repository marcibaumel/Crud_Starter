using BackendPartUpdated.DataManagment.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPartUpdated.DataManagment.Common.Models
{
    public class Result<T>
    {
        public T? Data { get; set; }
        public string Messages { get; set; }
        public bool HasError { get; set; }

        public Result(T data, string msgs, bool hasError)
        {
            Data = data;
            Messages = msgs;
            HasError = hasError;
        }

        public Result(T data)
        {
            Data = data;
        }
        public Result() { }
    }
}
