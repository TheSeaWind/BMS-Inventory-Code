
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class VehicleTypeFacade : BaseFacade
	{
		protected static VehicleTypeFacade instance = new VehicleTypeFacade(new VehicleTypeModel());
		protected VehicleTypeFacade(VehicleTypeModel model) : base(model)
		{
		}
		public static VehicleTypeFacade Instance
		{
			get { return instance; }
		}
		protected VehicleTypeFacade():base() 
		{ 
		} 
	
	}
}
	