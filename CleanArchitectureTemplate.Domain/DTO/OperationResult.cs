using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.DTO
{
    public class OperationResult
    {
        public bool IsSuccessful { get; set; }
        public Exception? Exception { get; set; }

        public OperationResult() { }
        private OperationResult(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }

        private OperationResult(bool isSuccessful, Exception exception)
        {
            IsSuccessful = isSuccessful;
            Exception = exception;
        }


        public static OperationResult Failure(Exception exception)
        {
            if (exception == null) throw new InvalidOperationException();
            return new OperationResult(false, exception);
        }

        public static OperationResult Success()
        {
            return new OperationResult(true);
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T? Data { get; }

        public OperationResult(bool isSuccessful, T? data, Exception? exception)
        {
            IsSuccessful = isSuccessful;
            Data = data;
            Exception = exception;
        }

        public OperationResult(bool isSuccessful, T? data)
        {
            IsSuccessful = isSuccessful;
            Data = data;
        }

        public OperationResult(bool isSuccessful, Exception? exception)
        {
            IsSuccessful = isSuccessful;
            Exception = exception;

        }

        public static OperationResult<T> Success(T data)
        {
            if (data == null) throw new InvalidOperationException();

            return new OperationResult<T>(true, data);
        }
        public static OperationResult<T> Failure(T data, Exception exception)
        {
            if (exception == null) throw new InvalidOperationException();
            return new OperationResult<T>(false, data, exception);
        }
    }

    public class OperationResult2 : OperationResult
    {

    }

}
