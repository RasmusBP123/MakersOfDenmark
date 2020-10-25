using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Responses
{
    public class Response
    {
        public Response(bool isSuccess, object result, List<string> errors = null)
        {
            IsSuccess = isSuccess;
            Errors = errors;
            Result = result;
        }

        public bool IsSuccess { get; }
        public List<string> Errors { get; }
        public object Result { get; }
    }
}
