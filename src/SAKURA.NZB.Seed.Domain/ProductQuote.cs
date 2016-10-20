namespace SAKURA.NZB.Seed.Domain
{
	public class ProductQuote
    {
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int SupplierId { get; set; }
		public Supplier Supplier { get; set; }
		public float Price { get; set; }
	}
}
