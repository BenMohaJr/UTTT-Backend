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
            _context = context;
        }

        public DataContext Cpntext { get; }

        public bool CreateGame(Games game)
        {
            _context.Add(game);
            return Save();
        }

        public bool GameExist(int id)
        {
            return _context.Games.Any(g => g.Id == id);
        }

        public ICollection<Games> GetGames()
        {
            return _context.Games.OrderBy(g => g.Id).ToList();
        }

        public Games GetGames(int id)
        {
            return _context.Games.Where(g => g.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}

