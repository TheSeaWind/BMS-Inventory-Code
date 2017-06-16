
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ParkingBlockBO : BaseBO
	{
		private ParkingBlockFacade facade = ParkingBlockFacade.Instance;
		protected static ParkingBlockBO instance = new ParkingBlockBO();

		protected ParkingBlockBO()
		{
			this.baseFacade = facade;
		}

		public static ParkingBlockBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	