namespace TwilioDotnetExample.Core.Utilities.Result
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : this(data, success, string.Empty)
        {
        }

        public T Data { get; init; }
    }
}
