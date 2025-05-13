namespace Alessio.Marchese.Utils.Core;

using System.Diagnostics.CodeAnalysis;
public class Result<T>
{
    [MemberNotNullWhen(false, nameof(ErrorMessage))]
    [MemberNotNullWhen(true, nameof(Data))]
    public bool IsSuccessful { get; }
    public string? ErrorMessage { get; }
    public T? Data { get; }

    private Result(bool isSuccessful, T? value, string? errorMessage)
    {
        IsSuccessful = isSuccessful;
        ErrorMessage = errorMessage;
        Data = value;
    }

    public static Result<T> Success(T value)
        => new(true, value, null);

    public static Result<T> Failure(string errorMessage)
        => new(false, default, errorMessage);

    public Result<U> ToResult<U>()
    {
        if (this.IsSuccessful)
            throw new InvalidOperationException("ToResult<U> Can only be used on a failed Result.");

        return Result<U>.Failure(this.ErrorMessage);
    }
}

public class Result
{
    [MemberNotNullWhen(false, nameof(ErrorMessage))]
    public bool IsSuccessful { get; }
    public string? ErrorMessage { get; }

    public Result(bool isSuccessful, string? errorMessage)
    {
        IsSuccessful = isSuccessful;
        ErrorMessage = errorMessage;
    }

    public static Result Success() =>
        new(true, null);

    public static Result Failure(string errorMessage) =>
        new(false, errorMessage);
}

