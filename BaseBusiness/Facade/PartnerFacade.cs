
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class PartnerFacade : BaseFacade
	{
		protected static PartnerFacade instance = new PartnerFacade(new PartnerModel());
		protected PartnerFacade(PartnerModel model) : base(model)
		{
		}
		public static PartnerFacade Instance
		{
			get { return instance; }
		}
		protected PartnerFacade():base() 
		{ 
		} 
	
	}
}
	