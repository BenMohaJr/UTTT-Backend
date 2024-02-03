using System;
namespace Ultimate_Tic_Tac_Toe.Models
{
	public class MainBoard
	{
		public int Id { get; set; }

		public string BoardStatus { get; set; }

        public DateTime Start_Time { get; set; }

        public DateTime End_Time { get; set; }

		public ICollection<LocalBoard> LocalBoardID { get; set; }

	}
}