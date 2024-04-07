namespace TwilioDotnetExample.Core.Utilities.Result
{
    public interface IDataResult<T> : IResultClient
    {
        T Data { get; init; }
    }
}
