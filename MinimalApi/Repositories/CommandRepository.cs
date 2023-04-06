using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Models;

namespace MinimalApi.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        private readonly CommandDbContext _dbContext;

        public CommandRepository(CommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task CreateCommandAsync(Command command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            await _dbContext.AddAsync(command);
        }

        public void DeleteCommand(Command command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _dbContext.Commands.Remove(command);
        }

        public async Task<Command?> GetCommandByIdAsync(Guid id)
        {
            return await _dbContext.Commands.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Command>> GetCommandsAsync()
        {
            return await _dbContext.Commands.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}