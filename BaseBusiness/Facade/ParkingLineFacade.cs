
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ParkingLineFacade : BaseFacade
	{
		protected static ParkingLineFacade instance = new ParkingLineFacade(new ParkingLineModel());
		protected ParkingLineFacade(ParkingLineModel model) : base(model)
		{
		}
		public static ParkingLineFacade Instance
		{
			get { return instance; }
		}
		protected ParkingLineFacade():base() 
		{ 
		} 
	
	}
}
	