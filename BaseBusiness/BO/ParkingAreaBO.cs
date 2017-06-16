
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ParkingAreaBO : BaseBO
	{
		private ParkingAreaFacade facade = ParkingAreaFacade.Instance;
		protected static ParkingAreaBO instance = new ParkingAreaBO();

		protected ParkingAreaBO()
		{
			this.baseFacade = facade;
		}

		public static ParkingAreaBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	