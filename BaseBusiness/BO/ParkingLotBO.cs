
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ParkingLotBO : BaseBO
	{
		private ParkingLotFacade facade = ParkingLotFacade.Instance;
		protected static ParkingLotBO instance = new ParkingLotBO();

		protected ParkingLotBO()
		{
			this.baseFacade = facade;
		}

		public static ParkingLotBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	