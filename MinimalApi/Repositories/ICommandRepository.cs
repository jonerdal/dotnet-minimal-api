using MinimalApi.Models;

namespace MinimalApi.Repositories
{
    public interface ICommandRepository
    {
        Task SaveChangesAsync();
        Task<Command?> GetCommandByIdAsync(Guid id);
        Task<IEnumerable<Command>> GetCommandsAsync();
        Task CreateCommandAsync(Command command);

        void DeleteCommand(Command command);
    }
}