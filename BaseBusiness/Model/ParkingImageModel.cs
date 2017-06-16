
using System;
namespace BMS.Model
{
	public class ParkingImageModel : BaseModel
	{
		private int iD;
		private int parkingID;
		private string image1;
		private string image2;
		private string image3;
		private string image4;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ParkingID
		{
			get { return parkingID; }
			set { parkingID = value; }
		}
	
		public string Image1
		{
			get { return image1; }
			set { image1 = value; }
		}
	
		public string Image2
		{
			get { return image2; }
			set { image2 = value; }
		}
	
		public string Image3
		{
			get { return image3; }
			set { image3 = value; }
		}
	
		public string Image4
		{
			get { return image4; }
			set { image4 = value; }
		}
	
	}
}
	