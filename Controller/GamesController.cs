using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ultimate_Tic_Tac_Toe.Dto;
using Ultimate_Tic_Tac_Toe.Interfaces;
using Ultimate_Tic_Tac_Toe.Models;
using Ultimate_Tic_Tac_Toe.Repository;

namespace Ultimate_Tic_Tac_Toe.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IMapper _mapper;

        public GamesController(IGamesRepository gamesRepository, IMapper mapper)
        {
            this._gamesRepository = gamesRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Games>))]
        [ProducesResponseType(400)] // Specify 400 for Bad Request
        [ProducesResponseType(404)] // Specify 404 for Not Found
        public IActionResult GetGames()
        {
            var Games = _mapper.Map<List<GamesDto>>(_gamesRepository.GetGames());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Games);
        }

        [HttpGet("{gameID}")]
        [ProducesResponseType(200, Type = typeof(Games))]
        [ProducesResponseType(400)] // Specify 400 for Bad Request
        [ProducesResponseType(404)] // Specify 404 for Not Found
        public IActionResult GetPlayer(int gameID)
        {
            if (!_gamesRepository.GameExist(gameID))
                return NotFound();

            var game = _mapper.Map<GamesDto>(_gamesRepository.GetGames(gameID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(game);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateGame([FromBody] GamesDto gameCreate)
        {
            if (gameCreate == null)
                return BadRequest(ModelState);

            var game = _gamesRepository.GetGames()
                .Where(g => g.Id == gameCreate.Id).FirstOrDefault();     

            if (game != null)
            {
                ModelState.AddModelError("", "ID already exist");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gameMap = _mapper.Map<Games>(gameCreate);

            if (!_gamesRepository.CreateGame(gameMap))
            {
                ModelState.AddModelError("", "Something went wront while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created");

        }
    }
}

