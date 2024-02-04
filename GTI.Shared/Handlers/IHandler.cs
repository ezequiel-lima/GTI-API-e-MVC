using GTI.Shared.Commands.Interfaces;

namespace GTI.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
