using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAKURA.NZB.Seed.Domain
{
	public class Shipment : IEquatable<Shipment>
	{
		public int Id { get; set; }
		[MaxLength(20)]
		public string TrackingNumber { get; set; }
		[MaxLength(20)]
		public string From { get; set; }
		[MaxLength(20)]
		public string Destination { get; set; }
		[MaxLength(10)]
		public string ItemCount { get; set; }
		[MaxLength(20)]
		public string Status { get; set; }

		public DateTimeOffset ModifiedTime { get; set; }
		public DateTime? ArrivedTime { get; set; }
		[MaxLength(20)]
		public string Recipient { get; set; }

		public List<ShipmentEntry> Entries { get; set; }

		public bool Equals(Shipment other)
		{
			return TrackingNumber == other.TrackingNumber
				&& From == other.From
				&& Destination == other.Destination
				&& ItemCount == other.ItemCount
				&& Status == other.Status
				&& ArrivedTime == other.ArrivedTime
				&& Recipient == other.Recipient
				&& Entries.Count == other.Entries.Count;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;

			return Equals(obj as Shipment);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = 13;
				hashCode = (hashCode * 397) ^ (!string.IsNullOrEmpty(TrackingNumber) ? TrackingNumber.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (!string.IsNullOrEmpty(From) ? From.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (!string.IsNullOrEmpty(Destination) ? Destination.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (!string.IsNullOrEmpty(ItemCount) ? ItemCount.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (!string.IsNullOrEmpty(Status) ? Status.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (!string.IsNullOrEmpty(Recipient) ? Recipient.GetHashCode() : 0);

				hashCode = (hashCode * 397) ^ (ArrivedTime.HasValue ? ArrivedTime.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Entries.Count;

				return hashCode;
			}
		}
	}
}
