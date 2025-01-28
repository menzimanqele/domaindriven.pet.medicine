namespace Wpm.Management.Api.Application;

public interface ICommandHandler<T>
{
    Task Handler(T command);
}