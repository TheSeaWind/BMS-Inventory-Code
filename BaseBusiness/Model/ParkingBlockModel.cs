
using System;
namespace BMS.Model
{
	public class ParkingBlockModel : BaseModel
	{
		private int iD;
		private int parkingAreaID;
		private string code;
		private string name;
		private bool active;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ParkingAreaID
		{
			get { return parkingAreaID; }
			set { parkingAreaID = value; }
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
	