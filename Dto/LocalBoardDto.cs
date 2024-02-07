using System;
namespace Ultimate_Tic_Tac_Toe.Dto
{
	public class LocalBoardDto
	{
        public int Id { get; set; }

        public int CellX { get; set; }

        public int CellY { get; set; }

        public Boolean TileIsOccupied { get; set; }

        public Boolean BoardIsActive { get; set; }
    }
}

