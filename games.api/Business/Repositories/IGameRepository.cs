using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using games.api.Business.Entities;

namespace games.api.Business.Repositories
{
    public interface IGameRepository : IDisposable
    {
        Task<List<Game>> GetAll(int page, int quantity);
        Task<Game> GetById(Guid id);
        Task<List<Game>> GetByNameAndProducer(string name, string producer);
        Task Create(Game game);
        Task Update(Game game);
        Task Delete(Guid id);
    }
}