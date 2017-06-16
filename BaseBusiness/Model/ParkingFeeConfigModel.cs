
using System;
namespace BMS.Model
{
	public class ParkingFeeConfigModel : BaseModel
	{
		private int iD;
		private int parkingLotID;
		private int vehicleTypeID;
		private int startDayTime;
		private int endDayTime;
		private decimal dayFee;
		private decimal nightFee;
		private decimal allDayFee;
		private bool blog24H;
		private bool nightCalculate;
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
	
		public int VehicleTypeID
		{
			get { return vehicleTypeID; }
			set { vehicleTypeID = value; }
		}
	
		public int StartDayTime
		{
			get { return startDayTime; }
			set { startDayTime = value; }
		}
	
		public int EndDayTime
		{
			get { return endDayTime; }
			set { endDayTime = value; }
		}
	
		public decimal DayFee
		{
			get { return dayFee; }
			set { dayFee = value; }
		}
	
		public decimal NightFee
		{
			get { return nightFee; }
			set { nightFee = value; }
		}
	
		public decimal AllDayFee
		{
			get { return allDayFee; }
			set { allDayFee = value; }
		}
	
		public bool Blog24H
		{
			get { return blog24H; }
			set { blog24H = value; }
		}
	
		public bool NightCalculate
		{
			get { return nightCalculate; }
			set { nightCalculate = value; }
		}
	
	}
}
	