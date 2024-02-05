using System;
using Ultimate_Tic_Tac_Toe.Models;

namespace Ultimate_Tic_Tac_Toe.Dto
{
	public class GamesDto
	{
        public int Id { get; set; }

        public MainBoard MainBoardID { get; set; }

        public int UserNameWins { get; set; }

        public int UserNameLosses { get; set; }
    }
}

