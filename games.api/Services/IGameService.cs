using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using games.api.Models.Game;

namespace games.api.Services
{
    public interface IGameService : IDisposable
    {
        Task<List<GameViewModelOutput>> GetAll(int page, int quantity);
        Task<GameViewModelOutput> GetById(Guid id);
        Task<GameViewModelOutput> Create(GameViewModelInput game);
        Task Update(Guid id, GameViewModelInput game);
        Task Update(Guid id, double price);
        Task Delete(Guid id);
    }
}