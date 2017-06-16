
using System;
namespace BMS.Model
{
	public class ParkingModel : BaseModel
	{
		private int iD;
		private int parkingPalletID;
		private int parkingCardID;
		private DateTime? inTime;
		private DateTime? outTime;
		private int parkingTypeID;
		private int vehicleTypeID;
		private string inLicensePlate;
		private string outLicensePlate;
		private string personName;
		private int companyID;
		private string inImagePath1;
		private string inImagePath2;
		private string outImagePath1;
		private string outImagePath2;
		private string inImage1;
		private string inImage2;
		private string outImage1;
		private string outImage2;
		private string inLPImage;
		private string outLPImage;
		private bool lostCard;
		private string comment;
		private DateTime? lostTimeUpdate;
		private decimal totalTime;
		private decimal parkingFee;
		private decimal lostCardPrice;
		private decimal totalPrice;
        private bool readLicensePlateOk;

        public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ParkingPalletID
		{
			get { return parkingPalletID; }
			set { parkingPalletID = value; }
		}
	
		public int ParkingCardID
		{
			get { return parkingCardID; }
			set { parkingCardID = value; }
		}
	
		public DateTime? InTime
		{
			get { return inTime; }
			set { inTime = value; }
		}
	
		public DateTime? OutTime
		{
			get { return outTime; }
			set { outTime = value; }
		}
	
		public int ParkingTypeID
		{
			get { return parkingTypeID; }
			set { parkingTypeID = value; }
		}
	
		public int VehicleTypeID
		{
			get { return vehicleTypeID; }
			set { vehicleTypeID = value; }
		}
	
		public string InLicensePlate
		{
			get { return inLicensePlate; }
			set { inLicensePlate = value; }
		}
	
		public string OutLicensePlate
		{
			get { return outLicensePlate; }
			set { outLicensePlate = value; }
		}
	
		public string PersonName
		{
			get { return personName; }
			set { personName = value; }
		}
	
		public int CompanyID
		{
			get { return companyID; }
			set { companyID = value; }
		}
	
		public string InImagePath1
		{
			get { return inImagePath1; }
			set { inImagePath1 = value; }
		}
	
		public string InImagePath2
		{
			get { return inImagePath2; }
			set { inImagePath2 = value; }
		}
	
		public string OutImagePath1
		{
			get { return outImagePath1; }
			set { outImagePath1 = value; }
		}
	
		public string OutImagePath2
		{
			get { return outImagePath2; }
			set { outImagePath2 = value; }
		}
	
		public string InImage1
		{
			get { return inImage1; }
			set { inImage1 = value; }
		}
	
		public string InImage2
		{
			get { return inImage2; }
			set { inImage2 = value; }
		}
	
		public string OutImage1
		{
			get { return outImage1; }
			set { outImage1 = value; }
		}
	
		public string OutImage2
		{
			get { return outImage2; }
			set { outImage2 = value; }
		}
	
		public string InLPImage
		{
			get { return inLPImage; }
			set { inLPImage = value; }
		}
	
		public string OutLPImage
		{
			get { return outLPImage; }
			set { outLPImage = value; }
		}
	
		public bool LostCard
		{
			get { return lostCard; }
			set { lostCard = value; }
		}
	
		public string Comment
		{
			get { return comment; }
			set { comment = value; }
		}
	
		public DateTime? LostTimeUpdate
		{
			get { return lostTimeUpdate; }
			set { lostTimeUpdate = value; }
		}
	
		public decimal TotalTime
		{
			get { return totalTime; }
			set { totalTime = value; }
		}
	
		public decimal ParkingFee
		{
			get { return parkingFee; }
			set { parkingFee = value; }
		}
	
		public decimal LostCardPrice
		{
			get { return lostCardPrice; }
			set { lostCardPrice = value; }
		}
	
		public decimal TotalPrice
		{
			get { return totalPrice; }
			set { totalPrice = value; }
		}
	    
        public bool ReadLicensePlateOk
        {
            get { return readLicensePlateOk; }
            set { readLicensePlateOk = value; }
        }

    }
}
	