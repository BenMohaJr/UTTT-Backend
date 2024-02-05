using System;
using Microsoft.EntityFrameworkCore;
using Ultimate_Tic_Tac_Toe.Data;
using Ultimate_Tic_Tac_Toe.Interfaces;
using Ultimate_Tic_Tac_Toe.Models;

namespace Ultimate_Tic_Tac_Toe.Repository
{
    public class GamesRepository : IGamesRepository
    {
        private readonly DataContext _context;

        public GamesRepository(DataContext context)
        {
            this._context = context;
        }

        public DataContext Cpntext { get; }

        public bool GameExist(int id)
        {
            return _context.Games.Any(g => g.Id == id);
        }

        public ICollection<Games> GetGames()
        {
            return _context.Games.ToList();
        }

        public Games GetGames(int id)
        {
            return _context.Games
                 .Include(g => g.MainBoardID) // Include the MainBoardID navigation property
                 .FirstOrDefault(e => e.Id == id);
        }
    }
}

