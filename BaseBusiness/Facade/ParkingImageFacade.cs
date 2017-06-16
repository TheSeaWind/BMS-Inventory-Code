
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ParkingImageFacade : BaseFacade
	{
		protected static ParkingImageFacade instance = new ParkingImageFacade(new ParkingImageModel());
		protected ParkingImageFacade(ParkingImageModel model) : base(model)
		{
		}
		public static ParkingImageFacade Instance
		{
			get { return instance; }
		}
		protected ParkingImageFacade():base() 
		{ 
		} 
	
	}
}
	