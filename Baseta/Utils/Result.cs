namespace Baseta.Utils
{
    public class Result
    {
        public bool Success { get; set; }
        public string MessageCode { get; set; } = null!;

        public static Result Ok(string messageCode)
        {
            return new Result { Success = true, MessageCode = messageCode };
        }

        public static Result Error(string messageCode)
        {
            return new Result { Success = false, MessageCode = messageCode };
        }
    }

    public class Result<T> : Result
    {
        public T Data { get; set; } = default!;

        public static Result<T> Ok(string messageCode, T data)
        {
            return new Result<T>
            {
                Success = true,
                MessageCode = messageCode,
                Data = data,
            };
        }

        public static Result<T> Error(string messageCode, T data)
        {
            return new Result<T>
            {
                Success = false,
                MessageCode = messageCode,
                Data = data,
            };
        }
    }
}