using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using games.api.Exceptions;
using games.api.Models;
using games.api.Models.Game;
using games.api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace games.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _service;
        
        public GamesController(IGameService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get All Games Registered and show those games using pagination
        /// </summary>
        /// <param name="page"></param>
        /// <param name="quantity"></param>
        /// <returns>Status Ok, games' data</returns>
        [SwaggerResponse(statusCode: 200, description: "Success to get", Type = typeof(GameViewModelInput))]
        [SwaggerResponse(statusCode: 500, description: "Server Error", Type = typeof(GenericErrorViewModel))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameViewModelOutput>>> GetAll([FromQuery, Range(1, int.MaxValue)] int page = 1, [FromQuery, Range(1, 50)] int quantity = 5)
        {
            var games = await _service.GetAll(page, quantity);

            if (games.Count() == 0)
                return NoContent();

            return Ok(games);
        }

        /// <summary>
        /// Get the game using its Id
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns>Status Ok, game's data</returns>
        [SwaggerResponse(statusCode: 200, description: "Success to get", Type = typeof(GameViewModelInput))]
        [SwaggerResponse(statusCode: 500, description: "Server Error", Type = typeof(GenericErrorViewModel))]
        [HttpGet("{gameId:guid}")]
        public async Task<ActionResult<GameViewModelOutput>> GetById([FromRoute] Guid gameId)
        {
            var game = await _service.GetById(gameId);

            if (game == null)
                return NoContent();

            return Ok(game);
        }

        /// <summary>
        /// Post a game in the system
        /// </summary>
        /// <param name="gameViewModelInput"></param>
        /// <returns>Status Ok, game's data</returns>
        [SwaggerResponse(statusCode: 201, description: "Success to Register", Type = typeof(GameViewModelInput))]
        [SwaggerResponse(statusCode: 500, description: "Server Error", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        public async Task<ActionResult<GameViewModelOutput>> Create([FromBody] GameViewModelInput gameViewModelInput)
        {
            try
            {
                var jogo = await _service.Create(gameViewModelInput);

                return Ok(jogo);
            }
            catch (GameAlreadyRegisteredException ex)
            {
                return UnprocessableEntity("Already Exists a game with this name for this producer registered");
            }
        }

        /// <summary>
        /// Put a game, in other words, update all game's field
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="gameViewModelInput"></param>
        /// <returns>Status Ok</returns>
        [SwaggerResponse(statusCode: 201, description: "Success to Update", Type = typeof(GameViewModelInput))]
        [SwaggerResponse(statusCode: 500, description: "Server Error", Type = typeof(GenericErrorViewModel))]
        [HttpPut("{gameId:guid}")]
        public async Task<ActionResult> UpdateGame([FromRoute] Guid gameId, [FromBody] GameViewModelInput gameViewModelInput)
        {
            try
            {
                await _service.Update(gameId, gameViewModelInput);

                return Ok();
            }
            catch (GameNotFoundException ex)
            {
                return NotFound("Game Doesn't Exist");
            }
        }

        /// <summary>
        /// Patch a game, in other words, update just the game's price
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="price"></param>
        /// <returns>Status Ok</returns>
        [SwaggerResponse(statusCode: 201, description: "Success to Update", Type = typeof(GameViewModelInput))]
        [SwaggerResponse(statusCode: 500, description: "Server Error", Type = typeof(GenericErrorViewModel))]
        [HttpPatch("{gameId:guid}/price/{price:double}")]
        public async Task<ActionResult> UpdateGamePrice([FromRoute] Guid gameId, [FromRoute] double price)
        {
            try
            {
                await _service.Update(gameId, price);

                return Ok();
            }
            catch (GameNotFoundException ex)
            {
                return NotFound("This game doesn't exists");
            }
        }

        /// <summary>
        /// Delete a game using its id
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns>Status Ok</returns>
        [SwaggerResponse(statusCode: 201, description: "Success to Delete", Type = typeof(GameViewModelInput))]
        [SwaggerResponse(statusCode: 500, description: "Server Error", Type = typeof(GenericErrorViewModel))]
        [HttpDelete("{gameId:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid gameId)
        {
            try
            {
                await _service.Delete(gameId);

                return Ok();
            }
            catch (GameNotFoundException ex)
            {
                return NotFound("This game doesn't exists");
            }
        }
    }
}