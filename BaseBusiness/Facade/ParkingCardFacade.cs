
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ParkingCardFacade : BaseFacade
	{
		protected static ParkingCardFacade instance = new ParkingCardFacade(new ParkingCardModel());
		protected ParkingCardFacade(ParkingCardModel model) : base(model)
		{
		}
		public static ParkingCardFacade Instance
		{
			get { return instance; }
		}
		protected ParkingCardFacade():base() 
		{ 
		} 
	
	}
}
	