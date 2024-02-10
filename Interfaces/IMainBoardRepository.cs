using System;
using Ultimate_Tic_Tac_Toe.Models;

namespace Ultimate_Tic_Tac_Toe.Interfaces
{
	public interface IMainBoardRepository
	{
		ICollection<MainBoard> getMainBoards();

		MainBoard GetMainBoards(int boardID);

		bool MainBoardExist(int boardID);
        bool CreateMainBoard(MainBoard board);
        bool Save();
    }
}

