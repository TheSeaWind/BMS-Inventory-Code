
using System;
namespace BMS.Model
{
	public class ParkingAreaModel : BaseModel
	{
		private int iD;
		private int parkingLotID;
		private string code;
		private string name;
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
	
		public bool Active
		{
			get { return active; }
			set { active = value; }
		}
	
	}
}
	