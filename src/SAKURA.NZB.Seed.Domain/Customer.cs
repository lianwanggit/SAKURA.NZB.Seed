using System.ComponentModel.DataAnnotations;

namespace SAKURA.NZB.Seed.Domain
{
	public class Customer
    {
		public int Id { get; set; }

		[MaxLength(10)]
		public string FullName { get; set; }

		[MaxLength(50)]
		public string NamePinYin { get; set; }

		[MaxLength(20)]
		public string Phone1 { get; set; }

		[MaxLength(20)]
		public string Phone2 { get; set; }

		[MaxLength(100)]
		public string Address { get; set; }

		[MaxLength(100)]
		public string Address1 { get; set; }

		[MaxLength(50)]
		public string Email { get; set; }

		public bool? IsAgent { get; set; }

		public int? Level { get; set; }

		[MaxLength(255)]
		public string Description { get; set; }
	}
}
