using System;
using Ultimate_Tic_Tac_Toe.Models;

namespace Ultimate_Tic_Tac_Toe.Interfaces
{
	public interface IGamesRepository
	{
		ICollection<Games> GetGames();
		Games GetGames(int id);
		bool GameExist(int id);
        bool CreateGame(Games game);
        bool Save();

    }
}

