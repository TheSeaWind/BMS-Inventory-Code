
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ParkingLotFacade : BaseFacade
	{
		protected static ParkingLotFacade instance = new ParkingLotFacade(new ParkingLotModel());
		protected ParkingLotFacade(ParkingLotModel model) : base(model)
		{
		}
		public static ParkingLotFacade Instance
		{
			get { return instance; }
		}
		protected ParkingLotFacade():base() 
		{ 
		} 
	
	}
}
	