
using System;
namespace BMS.Model
{
	public class ParkingGateModel : BaseModel
	{
		private int iD;
		private string parkingGateCode;
		private string parkingGateName;
		private int parkingLotID;
		private bool active;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string ParkingGateCode
		{
			get { return parkingGateCode; }
			set { parkingGateCode = value; }
		}
	
		public string ParkingGateName
		{
			get { return parkingGateName; }
			set { parkingGateName = value; }
		}
	
		public int ParkingLotID
		{
			get { return parkingLotID; }
			set { parkingLotID = value; }
		}
	
		public bool Active
		{
			get { return active; }
			set { active = value; }
		}
	
	}
}
	