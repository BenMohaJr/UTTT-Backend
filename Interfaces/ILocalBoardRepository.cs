using System;
using Ultimate_Tic_Tac_Toe.Models;

namespace Ultimate_Tic_Tac_Toe.Interfaces
{
	public interface ILocalBoardRepository
	{

		ICollection<LocalBoard> GetLocalBoards();

		LocalBoard GetLocalBoards(int localboardID);

		bool LocalBoardExist(int localboardID);
        bool CreateLocalBoard(LocalBoard board);
        bool Save();

    }
}

