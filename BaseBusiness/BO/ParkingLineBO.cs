
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ParkingLineBO : BaseBO
	{
		private ParkingLineFacade facade = ParkingLineFacade.Instance;
		protected static ParkingLineBO instance = new ParkingLineBO();

		protected ParkingLineBO()
		{
			this.baseFacade = facade;
		}

		public static ParkingLineBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	