
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ParkingGateBO : BaseBO
	{
		private ParkingGateFacade facade = ParkingGateFacade.Instance;
		protected static ParkingGateBO instance = new ParkingGateBO();

		protected ParkingGateBO()
		{
			this.baseFacade = facade;
		}

		public static ParkingGateBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	