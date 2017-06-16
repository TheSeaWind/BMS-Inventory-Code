
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ParkingTypeFacade : BaseFacade
	{
		protected static ParkingTypeFacade instance = new ParkingTypeFacade(new ParkingTypeModel());
		protected ParkingTypeFacade(ParkingTypeModel model) : base(model)
		{
		}
		public static ParkingTypeFacade Instance
		{
			get { return instance; }
		}
		protected ParkingTypeFacade():base() 
		{ 
		} 
	
	}
}
	