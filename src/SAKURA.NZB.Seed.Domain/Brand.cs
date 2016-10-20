using System.ComponentModel.DataAnnotations;

namespace SAKURA.NZB.Seed.Domain
{
	public class Brand
    {
		public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }
	}
}
