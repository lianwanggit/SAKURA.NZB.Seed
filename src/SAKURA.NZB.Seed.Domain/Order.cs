using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAKURA.NZB.Seed.Domain
{
	public class Order
    {
		public int Id { get; set; }
		public List<OrderProduct> Products { get; set; }
		public DateTimeOffset OrderTime { get; set; }
		public DateTimeOffset? DeliveryTime { get; set; }
		public DateTimeOffset? ReceiveTime { get; set; }
		public DateTimeOffset? PayTime { get; set; }
		public DateTimeOffset? CompleteTime { get; set; }
		public OrderState OrderState { get; set; }
		public PaymentState PaymentState { get; set; }
		[MaxLength(50)]
		public string TrackingNumber { get; set; }
		public float? Weight { get; set; }
		public float? Freight { get; set; }
		[MaxLength(255)]
		public string Description { get; set; }
		[MaxLength(10)]
		public string Recipient { get; set; }
		[MaxLength(20)]
		public string Phone { get; set; }
		[MaxLength(100)]
		public string Address { get; set; }
	}
}
