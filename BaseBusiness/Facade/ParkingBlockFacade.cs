
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ParkingBlockFacade : BaseFacade
	{
		protected static ParkingBlockFacade instance = new ParkingBlockFacade(new ParkingBlockModel());
		protected ParkingBlockFacade(ParkingBlockModel model) : base(model)
		{
		}
		public static ParkingBlockFacade Instance
		{
			get { return instance; }
		}
		protected ParkingBlockFacade():base() 
		{ 
		} 
	
	}
}
	