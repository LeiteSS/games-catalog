using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using games.api.Business.Entities;
using games.api.Business.Repositories;
using games.api.Exceptions;
using games.api.Models.Game;

namespace games.api.Services
{
    public class GameServiceImpl : IGameService
    {
        private readonly IGameRepository _repository;

        public GameServiceImpl(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<GameViewModelOutput> Create(GameViewModelInput game)
        {
            var gameFounded = await _repository.GetByNameAndProducer(game.Name, game.Producer);

            if (gameFounded.Count > 0)
                throw new GameAlreadyRegisteredException();

            var gameSaved = new Game
            {
                Id = Guid.NewGuid(),
                Name = game.Name,
                Producer = game.Producer,
                Price = game.Price
            };

            await _repository.Create(gameSaved);

            return new GameViewModelOutput
            {
                Id = gameSaved.Id,
                Name = game.Name,
                Producer = game.Producer,
                Price = game.Price
            };
        }

        public async Task Update(Guid id, GameViewModelInput game)
        {
            var gameFounded = await _repository.GetById(id);

            if (gameFounded == null)
                throw new GameNotFoundException();

            gameFounded.Name = game.Name;
            gameFounded.Producer = game.Producer;
            gameFounded.Price = game.Price;

            await _repository.Update(gameFounded);
        }

        public async Task Update(Guid id, double price)
        {
            var gameFounded = await _repository.GetById(id);

            if (gameFounded == null)
                throw new GameNotFoundException();

            gameFounded.Price = price;

            await _repository.Update(gameFounded);
        }

        public async Task Delete(Guid id)
        {
            var game = await _repository.GetById(id);

            if (game == null)
                throw new GameNotFoundException();

            await _repository.Delete(id);
        }

        public async Task<List<GameViewModelOutput>> GetAll(int page, int quantity)
        {
            var games = await _repository.GetAll(page, quantity);

            return games.Select(game => new GameViewModelOutput
                                {
                                    Id = game.Id,
                                    Name = game.Name,
                                    Producer = game.Producer,
                                    Price = game.Price
                                }).ToList();
        }

        public async Task<GameViewModelOutput> GetById(Guid id)
        {
            var game = await _repository.GetById(id);

            if (game == null)
                return null;

            return new GameViewModelOutput
            {
                Id = game.Id,
                Name = game.Name,
                Producer = game.Producer,
                Price = game.Price
            };
        }

        
        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}