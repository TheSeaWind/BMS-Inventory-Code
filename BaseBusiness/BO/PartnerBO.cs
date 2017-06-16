
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class PartnerBO : BaseBO
	{
		private PartnerFacade facade = PartnerFacade.Instance;
		protected static PartnerBO instance = new PartnerBO();

		protected PartnerBO()
		{
			this.baseFacade = facade;
		}

		public static PartnerBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	