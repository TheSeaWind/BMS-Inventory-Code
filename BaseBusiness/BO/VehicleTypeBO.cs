
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class VehicleTypeBO : BaseBO
	{
		private VehicleTypeFacade facade = VehicleTypeFacade.Instance;
		protected static VehicleTypeBO instance = new VehicleTypeBO();

		protected VehicleTypeBO()
		{
			this.baseFacade = facade;
		}

		public static VehicleTypeBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	