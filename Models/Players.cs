using System;
namespace Ultimate_Tic_Tac_Toe.Models
{
	public class Players
	{
		public int Id { get; set; }

		public string UserName { get; set; }

		public ICollection<Games> GamesID { get; set; }
	}
}