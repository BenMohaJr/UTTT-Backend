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

        public bool CreatePlayer(Players player)
        {
            //Change Tracker
            // Add, Update, Modifying
            // Connected vs Disconnected.
            _context.Add(player);
            return Save();
        }

        public ICollection<Players> GetPlayers()
		{
			return _context.Players.OrderBy(p => p.Id).ToList();
		}

        public Players GetPlayers(int id)
        {
            return _context.Players.Where(p => p.Id == id).FirstOrDefault();
        }

        public Players GetPlayers(string username)
        {
            return _context.Players.Where(p => p.UserName == username).FirstOrDefault();
        }

        public bool PlayerExists(int PlayerID)
        {
            return _context.Players.Any(p => p.Id == PlayerID);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UpdatePlayer(Players player)
        {
            _context.Update(player);

            return Save();
        }
    }
}

