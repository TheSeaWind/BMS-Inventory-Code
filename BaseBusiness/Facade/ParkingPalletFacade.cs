
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ParkingPalletFacade : BaseFacade
	{
		protected static ParkingPalletFacade instance = new ParkingPalletFacade(new ParkingPalletModel());
		protected ParkingPalletFacade(ParkingPalletModel model) : base(model)
		{
		}
		public static ParkingPalletFacade Instance
		{
			get { return instance; }
		}
		protected ParkingPalletFacade():base() 
		{ 
		} 
	
	}
}
	