using System;
using AutoMapper;
using Ultimate_Tic_Tac_Toe.Data;
using Ultimate_Tic_Tac_Toe.Interfaces;
using Ultimate_Tic_Tac_Toe.Models;

namespace Ultimate_Tic_Tac_Toe.Repository
{
	public class LocalBoardRepository : ILocalBoardRepository
	{
        private readonly DataContext _context;

        public LocalBoardRepository(DataContext context)
		{
            _context = context;
        }

        public LocalBoard GetLocalBoards(int localboardID)
        {
            return _context.LocalBoard.Where(l => l.Id == localboardID).FirstOrDefault();
        }

        public ICollection<LocalBoard> GetLocalBoards()
        {
            return _context.LocalBoard.ToList();
        }

        public bool LocalBoardExist(int localboardID)
        {
            return _context.LocalBoard.Any(l => l.Id == localboardID);
        }
    }
}

