using System.ComponentModel.DataAnnotations;

namespace SAKURA.NZB.Seed.Domain
{
	public class OrderProduct
    {
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
		public Product Product { get; set; }
		[MaxLength(100)]
		public string ProductName { get; set; }
		public float Cost { get; set; }
		public float Price { get; set; }
		public int Qty { get; set; }
		public int OrderId { get; set; }
		public bool PrePurchased { get; set; }
	}
}
