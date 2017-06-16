
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ParkingFeeConfigFacade : BaseFacade
	{
		protected static ParkingFeeConfigFacade instance = new ParkingFeeConfigFacade(new ParkingFeeConfigModel());
		protected ParkingFeeConfigFacade(ParkingFeeConfigModel model) : base(model)
		{
		}
		public static ParkingFeeConfigFacade Instance
		{
			get { return instance; }
		}
		protected ParkingFeeConfigFacade():base() 
		{ 
		} 
	
	}
}
	