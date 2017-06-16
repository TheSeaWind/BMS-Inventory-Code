
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ParkingTypeBO : BaseBO
	{
		private ParkingTypeFacade facade = ParkingTypeFacade.Instance;
		protected static ParkingTypeBO instance = new ParkingTypeBO();

		protected ParkingTypeBO()
		{
			this.baseFacade = facade;
		}

		public static ParkingTypeBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	