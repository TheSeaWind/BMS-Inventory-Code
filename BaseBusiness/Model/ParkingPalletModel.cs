
using System;
namespace BMS.Model
{
	public class ParkingPalletModel : BaseModel
	{
		private int iD;
		private int parkingBlockID;
		private string code;
		private string name;
		private int vehicleTypeID;
		private bool active;
        private bool empty;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ParkingBlockID
		{
			get { return parkingBlockID; }
			set { parkingBlockID = value; }
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
	
		public int VehicleTypeID
		{
			get { return vehicleTypeID; }
			set { vehicleTypeID = value; }
		}
	
		public bool Active
		{
			get { return active; }
			set { active = value; }
		}
	    public bool Empty
        {
            get { return empty; }
            set { empty = value; }
        }
	}
}
	