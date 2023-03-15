namespace TestWebApi.Application.Exceptions;

public class DeleteEntityException : Exception
{
    public DeleteEntityException()
    {
    }

    public DeleteEntityException(string message)
        : base(message)
    {
    }

    public DeleteEntityException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public DeleteEntityException(string name, object key)
        : base($"{name} with ({key}) can not be deleted.")
    {
    }
}