
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ParkingFacade : BaseFacade
	{
		protected static ParkingFacade instance = new ParkingFacade(new ParkingModel());
		protected ParkingFacade(ParkingModel model) : base(model)
		{
		}
		public static ParkingFacade Instance
		{
			get { return instance; }
		}
		protected ParkingFacade():base() 
		{ 
		} 
	
	}
}
	