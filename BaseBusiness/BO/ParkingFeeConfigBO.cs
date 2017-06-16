
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ParkingFeeConfigBO : BaseBO
	{
		private ParkingFeeConfigFacade facade = ParkingFeeConfigFacade.Instance;
		protected static ParkingFeeConfigBO instance = new ParkingFeeConfigBO();

		protected ParkingFeeConfigBO()
		{
			this.baseFacade = facade;
		}

		public static ParkingFeeConfigBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	