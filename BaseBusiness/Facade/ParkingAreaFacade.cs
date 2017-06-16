
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ParkingAreaFacade : BaseFacade
	{
		protected static ParkingAreaFacade instance = new ParkingAreaFacade(new ParkingAreaModel());
		protected ParkingAreaFacade(ParkingAreaModel model) : base(model)
		{
		}
		public static ParkingAreaFacade Instance
		{
			get { return instance; }
		}
		protected ParkingAreaFacade():base() 
		{ 
		} 
	
	}
}
	