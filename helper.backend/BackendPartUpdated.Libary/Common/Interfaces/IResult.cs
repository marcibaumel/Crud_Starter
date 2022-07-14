using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPartUpdated.DataManagment.Common.Interfaces
{
    public interface IResult
    {
        T Data<T>(T value);
        bool HasError { get; }
        string Message { get; }
    }
}
