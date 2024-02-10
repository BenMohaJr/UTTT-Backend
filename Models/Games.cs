using System;
using System.Collections.Generic;

namespace Ultimate_Tic_Tac_Toe.Models
{
    public class Games
    {
        public int Id { get; set; }

        public ICollection<MainBoard> MainBoardID { get; set; }

        public int UserNameWins { get; set; }

        public int UserNameLosses { get; set; }
    }
}
