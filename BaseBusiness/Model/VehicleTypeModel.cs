
using System;
namespace BMS.Model
{
	public class VehicleTypeModel : BaseModel
	{
		private int iD;
		private int parkingLotID;
		private string code;
		private string name;
		private bool active;
		private decimal height;
		private decimal width;
		private decimal length;
		private decimal weight;
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
	
		public decimal Height
		{
			get { return height; }
			set { height = value; }
		}
	
		public decimal Width
		{
			get { return width; }
			set { width = value; }
		}
	
		public decimal Length
		{
			get { return length; }
			set { length = value; }
		}
	
		public decimal Weight
		{
			get { return weight; }
			set { weight = value; }
		}
	
	}
}
	