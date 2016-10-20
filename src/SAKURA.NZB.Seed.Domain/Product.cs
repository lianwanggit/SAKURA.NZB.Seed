using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAKURA.NZB.Seed.Domain
{
    public class Product
    {
		public int Id { get; set; }

		[MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(1000)]
		public string Desc { get; set; }

		public int CategoryId { get; set; }
		public Category Category { get; set; }

		public int BrandId { get; set; }
		public Brand Brand { get; set; }

		public List<ProductQuote> Quotes { get; set; }

		public float Price { get; set; }
	}
}
