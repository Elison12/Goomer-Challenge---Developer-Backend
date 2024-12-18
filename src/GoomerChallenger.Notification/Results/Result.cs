﻿using System.Net;

namespace GoomerChallenger.Notification.Results
{
    public class Result<T>
    {
        public T Data { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public static Result<T> Success(T data)
        {
            return new Result<T>
            {
                Data = data,
                StatusCode = HttpStatusCode.OK
            };
        }

        public static Result<T> Error(HttpStatusCode statusCode, string errorMessage)
        {
            return new Result<T>
            {
                StatusCode = statusCode,
                ErrorMessage = errorMessage
            };
        }
        public static Result<T> NotFound(HttpStatusCode statusCode, string errorMessage)
        {
            return new Result<T>
            {
                StatusCode = statusCode,
                ErrorMessage = errorMessage
            };
        }
    }
}
