using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpcomingMoviesBackend.Exceptions
{
    public class SyncException : Exception
    {
        public SyncException() { }
        public SyncException(string message, Exception innerException): base(message, innerException)
        {

        }
    }
}
