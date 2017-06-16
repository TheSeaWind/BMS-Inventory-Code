
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ParkingImageBO : BaseBO
	{
		private ParkingImageFacade facade = ParkingImageFacade.Instance;
		protected static ParkingImageBO instance = new ParkingImageBO();

		protected ParkingImageBO()
		{
			this.baseFacade = facade;
		}

		public static ParkingImageBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	