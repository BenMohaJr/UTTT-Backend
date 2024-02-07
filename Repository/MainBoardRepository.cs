using System;
using Ultimate_Tic_Tac_Toe.Data;
using Ultimate_Tic_Tac_Toe.Interfaces;
using Ultimate_Tic_Tac_Toe.Models;

namespace Ultimate_Tic_Tac_Toe.Repository

{
	public class MainBoardRepository : IMainBoardRepository
	{
        private readonly DataContext _context;

        public MainBoardRepository(DataContext context)
		{
            _context = context;
        }
        
        public MainBoard GetMainBoards(int boardID)
        {
            return _context.MainBoard.Where(m => m.Id == boardID).FirstOrDefault();
        }

        public ICollection<MainBoard> getMainBoards()
        {
            return _context.MainBoard.ToList();
        }

        public bool MainBoardExist(int boardID)
        {
            return _context.MainBoard.Any(m => m.Id == boardID);
        }
    }
}

