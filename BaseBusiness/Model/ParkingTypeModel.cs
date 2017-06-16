
using System;
namespace BMS.Model
{
	public class ParkingTypeModel : BaseModel
	{
		private int iD;
		private string parkingTypeCode;
		private string parkingTypeName;
		private bool active;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string ParkingTypeCode
		{
			get { return parkingTypeCode; }
			set { parkingTypeCode = value; }
		}
	
		public string ParkingTypeName
		{
			get { return parkingTypeName; }
			set { parkingTypeName = value; }
		}
	
		public bool Active
		{
			get { return active; }
			set { active = value; }
		}
	
	}
}
	