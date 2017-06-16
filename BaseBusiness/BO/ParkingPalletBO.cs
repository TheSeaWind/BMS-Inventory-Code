
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ParkingPalletBO : BaseBO
	{
		private ParkingPalletFacade facade = ParkingPalletFacade.Instance;
		protected static ParkingPalletBO instance = new ParkingPalletBO();

		protected ParkingPalletBO()
		{
			this.baseFacade = facade;
		}

		public static ParkingPalletBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	