
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class CameraBO : BaseBO
	{
		private CameraFacade facade = CameraFacade.Instance;
		protected static CameraBO instance = new CameraBO();

		protected CameraBO()
		{
			this.baseFacade = facade;
		}

		public static CameraBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	