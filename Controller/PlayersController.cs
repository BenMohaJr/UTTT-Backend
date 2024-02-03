using System;
using Microsoft.AspNetCore.Mvc;
using Ultimate_Tic_Tac_Toe.Interfaces;
using Ultimate_Tic_Tac_Toe.Models;


namespace Ultimate_Tic_Tac_Toe.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlayersController
	{
		private readonly IPlayersRepository _playersRepository;

		public PlayersController(IPlayersRepository playersRepository)
		{
			this._playersRepository = playersRepository;
		}
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Players>))]
		public IActionResult GetPlayers()
		{
			var Players = _playersRepository.GetPlayers();

            return (IActionResult)Players;
        }
    }
}

