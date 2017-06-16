
using System;
namespace BMS.Model
{
	public class ParkingCardModel : BaseModel
	{
		private int iD;
		private int parkingLotID;
		private string parkingCardCode;
		private string parkingCardName;
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
	
		public string ParkingCardCode
		{
			get { return parkingCardCode; }
			set { parkingCardCode = value; }
		}
	
		public string ParkingCardName
		{
			get { return parkingCardName; }
			set { parkingCardName = value; }
		}
	
		public bool Active
		{
			get { return active; }
			set { active = value; }
		}
	
	}
}
	