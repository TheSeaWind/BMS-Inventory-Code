
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ParkingCardBO : BaseBO
	{
		private ParkingCardFacade facade = ParkingCardFacade.Instance;
		protected static ParkingCardBO instance = new ParkingCardBO();

		protected ParkingCardBO()
		{
			this.baseFacade = facade;
		}

		public static ParkingCardBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	