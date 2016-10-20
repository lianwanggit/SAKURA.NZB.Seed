using System.ComponentModel.DataAnnotations;

namespace SAKURA.NZB.Seed.Domain
{
	public class Category
    {
		public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }
	}
}
