using System;
using System.ComponentModel.DataAnnotations;

namespace SAKURA.NZB.Seed.Domain
{
	public class ShipmentEntry
    {
		public int Id { get; set; }
		public int ShipmentId { get; set; }
		public DateTime? When { get; set; }
		[MaxLength(50)]
		public string Where { get; set; }
		[MaxLength(200)]
		public string Content { get; set; }
	}
}
