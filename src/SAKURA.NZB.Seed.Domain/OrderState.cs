namespace SAKURA.NZB.Seed.Domain
{
	public enum OrderState
	{
		Created = 0,
		Confirmed,
		Delivered,
		Clearance,
		Received,
		Completed
	}
}
