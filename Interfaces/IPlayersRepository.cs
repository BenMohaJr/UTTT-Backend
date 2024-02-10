using System;
using Ultimate_Tic_Tac_Toe.Models;

namespace Ultimate_Tic_Tac_Toe.Interfaces
{
	public interface IPlayersRepository
	{
		ICollection<Players> GetPlayers();
		Players GetPlayers(int id);
		Players GetPlayers(string username);
		bool PlayerExists(int PlayerID);
		bool CreatePlayer(Players player);
		bool Save();

	}

}

