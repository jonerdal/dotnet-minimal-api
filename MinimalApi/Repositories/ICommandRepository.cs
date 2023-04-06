using MinimalApi.Models;

namespace MinimalApi.Repositories
{
    public interface ICommandRepository
    {
        Task SaveChanges();
        Task<Command?> GetCommandById(Guid id);
        Task<IEnumerable<Command>> GetCommands();
        Task CreateCommand(Command command);

        void DeleteCommand(Command command);
    }
}