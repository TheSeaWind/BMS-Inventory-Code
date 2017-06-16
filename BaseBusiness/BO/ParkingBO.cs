
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ParkingBO : BaseBO
	{
		private ParkingFacade facade = ParkingFacade.Instance;
		protected static ParkingBO instance = new ParkingBO();

		protected ParkingBO()
		{
			this.baseFacade = facade;
		}

		public static ParkingBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	