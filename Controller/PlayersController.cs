using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ultimate_Tic_Tac_Toe.Dto;
using Ultimate_Tic_Tac_Toe.Interfaces;
using Ultimate_Tic_Tac_Toe.Models;


namespace Ultimate_Tic_Tac_Toe.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlayersController : ControllerBase
	{
		private readonly IPlayersRepository _playersRepository;
        private readonly IMapper _mapper;

        public PlayersController(IPlayersRepository playersRepository, IMapper mapper)
		{
			this._playersRepository = playersRepository;
            this._mapper = mapper;
        }


		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Players>))]
        [ProducesResponseType(400)] // Specify 400 for Bad Request
        [ProducesResponseType(404)] // Specify 404 for Not Found
        public IActionResult GetPlayers()
		{
			var Players = _mapper.Map<List<PlayersDto>>(_playersRepository.GetPlayers());

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

            return Ok(Players);
        }

		
		[HttpGet("{playerID}")]
		[ProducesResponseType(200, Type = typeof(Players))]
		[ProducesResponseType(400)] // Specify 400 for Bad Request
        [ProducesResponseType(404)] // Specify 404 for Not Found
        public IActionResult GetPlayer(int playerID)
		{
			if (!_playersRepository.PlayerExists(playerID))
				return NotFound();

			var player = _mapper.Map<PlayersDto>(_playersRepository.GetPlayers(playerID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

			return Ok(player);
        }

		[HttpPost]
		[ProducesResponseType(204)]
        [ProducesResponseType(400)]
		public IActionResult CreatePlayer([FromBody] PlayersDto playerCreate)
		{
			if (playerCreate == null)
				return BadRequest(ModelState);

			var player = _playersRepository.GetPlayers()
				.Where(p => p.UserName.Trim().ToUpper() == playerCreate.UserName.TrimEnd().ToUpper())
				.FirstOrDefault();

			if (player != null)
			{
				ModelState.AddModelError("", "username already exist");
				return StatusCode(422, ModelState);
			}

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var playerMap = _mapper.Map<Players>(playerCreate);

			if (!_playersRepository.CreatePlayer(playerMap))
			{
				ModelState.AddModelError("", "Something went wront while saving");
				return StatusCode(500, ModelState);
			}

			return Ok("Succesfully created");

		}

		[HttpPut("{playerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePlayer(int playerId, [FromBody]PlayersDto updatedPlayer)
		{
			if (updatedPlayer == null)
				return BadRequest(ModelState);

			if (playerId != updatedPlayer.Id)
				return BadRequest(ModelState);

			if (!_playersRepository.PlayerExists(playerId))
				return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

			var playerMap = _mapper.Map<Players>(updatedPlayer);

			if (!_playersRepository.UpdatePlayer(playerMap))
			{
				ModelState.AddModelError("", "Something went wrong updating player");
				return StatusCode(500, ModelState);
			}

			return NoContent();

			
        }
    }
}