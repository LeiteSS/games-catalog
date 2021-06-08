using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using games.api.Business.Entities;
using games.api.Business.Repositories;

namespace games.api.Infraestructure.Data.Repositories
{
    public class GameMySqlRepository : IGameRepository
    {
        private readonly GamesDbContext _context;

        public GameMySqlRepository(GamesDbContext context)
        {
            _context = context;
        }

        public async Task Create(Game game)
        {
            _context.Game.Add(game);
        }

        public async Task Delete(Guid id)
        {
            var gameFounded = _context.Game.Find(id);

            _context.Game.Remove(gameFounded);
        }

        public async Task Update(Game game)
        {
            _context.Game.Update(game);
        }

        
        public Task<List<Game>> GetAll(int page, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<Game> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Game>> GetByNameAndProducer(string name, string producer)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}