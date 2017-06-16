
using System;
namespace BMS.Model
{
	public class CustomerModel : BaseModel
	{
		private int iD;
		private int parkingLotID;
		private string code;
		private string name;
		private string phoneNumber;
		private string email;
		private string address;
		private int customerType;
		private bool active;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ParkingLotID
		{
			get { return parkingLotID; }
			set { parkingLotID = value; }
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
	
		public string PhoneNumber
		{
			get { return phoneNumber; }
			set { phoneNumber = value; }
		}
	
		public string Email
		{
			get { return email; }
			set { email = value; }
		}
	
		public string Address
		{
			get { return address; }
			set { address = value; }
		}
	
		public int CustomerType
		{
			get { return customerType; }
			set { customerType = value; }
		}
	
		public bool Active
		{
			get { return active; }
			set { active = value; }
		}
	
	}
}
	