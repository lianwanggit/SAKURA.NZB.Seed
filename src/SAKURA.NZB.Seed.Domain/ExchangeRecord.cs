using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAKURA.NZB.Seed.Domain
{
    public class ExchangeRecord
    {
		public int Id { get; set; }
		public float Cny { get; set; }
		public float Nzd { get; set; }
		public float SponsorCharge { get; set; }
		public float ReceiverCharge { get; set; }
		public float Rate { get; set; }
		public string Agent { get; set; }
		public DateTimeOffset CreatedTime { get; set; }
	}
}
