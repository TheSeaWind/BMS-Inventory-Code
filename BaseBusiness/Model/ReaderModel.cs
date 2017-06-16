
using System;
namespace BMS.Model
{
	public class ReaderModel : BaseModel
	{
		private int iD;
		private string readerCode;
		private string readerName;
		private int cOMPort;
		private string portMode;
		private bool active;
		private int parkingLotID;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string ReaderCode
		{
			get { return readerCode; }
			set { readerCode = value; }
		}
	
		public string ReaderName
		{
			get { return readerName; }
			set { readerName = value; }
		}
	
		public int COMPort
		{
			get { return cOMPort; }
			set { cOMPort = value; }
		}
	
		public string PortMode
		{
			get { return portMode; }
			set { portMode = value; }
		}
	
		public bool Active
		{
			get { return active; }
			set { active = value; }
		}
	
		public int ParkingLotID
		{
			get { return parkingLotID; }
			set { parkingLotID = value; }
		}
	
	}
}
	