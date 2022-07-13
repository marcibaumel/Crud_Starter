using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPartUpdated.DataManagment.Common.Interfaces
{
    public interface IResult
    {
        /// <summary>
        /// Gets a value indicating whether the result was successful.
        /// </summary>
        bool HasError { get; }

        /// <summary>
        /// Gets the error messages, if any.
        /// </summary>
        string[] Messages { get; }
    }
}
