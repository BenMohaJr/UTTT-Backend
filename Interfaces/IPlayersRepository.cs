using System;
using Ultimate_Tic_Tac_Toe.Models;

namespace Ultimate_Tic_Tac_Toe.Interfaces
{
	public interface IPlayersRepository
	{
		ICollection<Players> GetPlayers();
	}
}

