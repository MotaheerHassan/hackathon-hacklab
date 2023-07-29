using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESCS.Api.Dto
{
    public class APIModel<T>
    {
        public T Data { get; set; }
        public int Status { get; set; }
        public Error Error { get; set; }
    }

    public class Error
    {
        public Error(string message, string detailedMessage)
        {
            Message = message;
            DetailedMessage = detailedMessage;
        }
        public string Message { get; set; }
        public string DetailedMessage { get; set; }
    }
}
