﻿namespace ABCFitnessClassBooking
{
    public class Result<T>
    {
        public bool IsSuccess {  get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }

        public static Result<T> Success(T data)
        {
            return new Result<T> { IsSuccess = true, Data = data };
        }

        public static Result<T> Failure(string errorMessage)
        {
            return new Result<T> { IsSuccess = false, ErrorMessage = errorMessage };
        }
    }
}
