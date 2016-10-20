using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAKURA.NZB.Seed.Domain
{
	public class Configuration
    {
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None), MaxLength(200)]
		public string Key { get; set; }
		[MaxLength(1000)]
		public string Value { get; set; }
	}
}
