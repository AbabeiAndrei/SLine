using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRDS.DataLayer.Exceptions
{
    public class ControllerNullException : Exception
    {
        public ControllerNullException()
        {
        }

        public ControllerNullException(string message) : base(message)
        {
        }

        public ControllerNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ControllerNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
