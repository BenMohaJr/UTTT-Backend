using System;
using Ultimate_Tic_Tac_Toe.Data;
using Ultimate_Tic_Tac_Toe.Interfaces;
using Ultimate_Tic_Tac_Toe.Models;

namespace Ultimate_Tic_Tac_Toe.Repository
{
	public class PlayersRepository : IPlayersRepository
	{
		private readonly DataContext _context;
		public PlayersRepository(DataContext context)
		{
			_context = context;
		}

		public ICollection<Players> GetPlayers()
		{
			return _context.Players.OrderBy(p => p.Id).ToList();
		}
	}
}

