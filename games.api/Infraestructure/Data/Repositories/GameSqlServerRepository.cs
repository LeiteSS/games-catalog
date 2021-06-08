using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using games.api.Business.Entities;
using games.api.Business.Repositories;
using Microsoft.Extensions.Configuration;

namespace games.api.Infraestructure.Data.Repositories
{
    public class GameSqlServerRepository : IGameRepository
    {
        private readonly SqlConnection sqlConnection;

        public GameSqlServerRepository(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }
        public Task Create(Game game)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Game game)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}