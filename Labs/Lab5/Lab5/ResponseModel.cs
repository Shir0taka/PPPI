using System.Collections.Generic;
using System.Net;

namespace Lab5
{
    public class FactModel
    {
        public string Fact { get; set; }
        public int Length { get; set;}
    }

    public class ResponseModel<T>
    {
        public T Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public ResponseModel(T result, HttpStatusCode statusCode)
        {
            Result = result;
            StatusCode = statusCode;
            Message = string.Empty;
            Errors = new List<string>();
        }

        public ResponseModel(T result, HttpStatusCode statusCode, string message)
        {
            Result = result;
            StatusCode = statusCode;
            Message = message;
            Errors = new List<string>();
        }
    }
}