namespace TwilioDotnetExample.Core.Utilities.Result
{
    public interface IResultClient
    {
        bool Success { get; init; }
        string Message { get; init; }
    }
}
