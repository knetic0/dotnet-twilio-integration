namespace TwilioDotnetExample.Core.Utilities.Result
{
    public class Result : IResultClient
    {
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; init; }
        public string Message { get; init; } = string.Empty;
    }
}
