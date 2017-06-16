
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ParkingGateFacade : BaseFacade
	{
		protected static ParkingGateFacade instance = new ParkingGateFacade(new ParkingGateModel());
		protected ParkingGateFacade(ParkingGateModel model) : base(model)
		{
		}
		public static ParkingGateFacade Instance
		{
			get { return instance; }
		}
		protected ParkingGateFacade():base() 
		{ 
		} 
	
	}
}
	