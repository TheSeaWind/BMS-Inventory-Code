
using System;
namespace BMS.Model
{
	public class ParkingLotModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private bool active;
		private string address;
		private string phoneNumber;
		private int totalSlot;
		private int totalEmptySlot;
		private int totalBusySlot;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public bool Active
		{
			get { return active; }
			set { active = value; }
		}
	
		public string Address
		{
			get { return address; }
			set { address = value; }
		}
	
		public string PhoneNumber
		{
			get { return phoneNumber; }
			set { phoneNumber = value; }
		}
	
		public int TotalSlot
		{
			get { return totalSlot; }
			set { totalSlot = value; }
		}
	
		public int TotalEmptySlot
		{
			get { return totalEmptySlot; }
			set { totalEmptySlot = value; }
		}
	
		public int TotalBusySlot
		{
			get { return totalBusySlot; }
			set { totalBusySlot = value; }
		}
	
	}
}
	