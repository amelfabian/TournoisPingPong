using System;
using System.Runtime.Serialization;

namespace CouchesAccèsBD
{
    
    public class ExceptionAccesBD : Exception
    {
        private string Details { get; set; }
        public ExceptionAccesBD(string cause, string details)
        : base(cause)
        {
            Details = details;
        }
    }
}