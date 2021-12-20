using System;
using System.Net;

namespace MechanicWebAppAPI.Common.CustomExceptions
{

    public class ServiceLayerException : Exception
    {
        public HttpStatusCode StatusCode { get; protected set; }

        public ServiceLayerException(HttpStatusCode statusCode) : base()
        {
            StatusCode = statusCode;
        }
        public ServiceLayerException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public ServiceLayerException() : base()
        {
        }

        public ServiceLayerException(string message) : base(message)
        {
        }

        public ServiceLayerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
