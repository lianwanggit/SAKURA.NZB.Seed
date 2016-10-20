using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAKURA.NZB.Seed.Domain
{
    public class Supplier
    {
		public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }
		[MaxLength(100)]
		public string Address { get; set; }
		[MaxLength(20)]
		public string Phone { get; set; }
	}
}
