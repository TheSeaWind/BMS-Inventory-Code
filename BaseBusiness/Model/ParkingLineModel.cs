
using System;
namespace BMS.Model
{
	public class ParkingLineModel : BaseModel
	{
		private int iD;
		private string parkingLineCode;
		private string parkingLineName;
		private int parkingGateID;
		private bool active;
		private string parkingLineLocation;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string ParkingLineCode
		{
			get { return parkingLineCode; }
			set { parkingLineCode = value; }
		}
	
		public string ParkingLineName
		{
			get { return parkingLineName; }
			set { parkingLineName = value; }
		}
	
		public int ParkingGateID
		{
			get { return parkingGateID; }
			set { parkingGateID = value; }
		}
	
		public bool Active
		{
			get { return active; }
			set { active = value; }
		}
	
		public string ParkingLineLocation
		{
			get { return parkingLineLocation; }
			set { parkingLineLocation = value; }
		}
	
	}
}
	