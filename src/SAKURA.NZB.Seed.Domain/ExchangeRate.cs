using System;
using System.ComponentModel.DataAnnotations;

namespace SAKURA.NZB.Seed.Domain
{
	public class ExchangeRate
    {
		public int Id { get; set; }
		public float USDNZD { get; set; }
		public float USDCNY { get; set; }
		public float NZDCNY { get; set; }
		[MaxLength(50)]
		public string Source { get; set; }
		public DateTimeOffset ModifiedTime { get; set; }
	}
}
