
using System;
namespace BMS.Model
{
	public class PartnerModel : BaseModel
	{
		private int iD;
		private string partnerCode;
		private string partnerName;
		private bool active;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string PartnerCode
		{
			get { return partnerCode; }
			set { partnerCode = value; }
		}
	
		public string PartnerName
		{
			get { return partnerName; }
			set { partnerName = value; }
		}
	
		public bool Active
		{
			get { return active; }
			set { active = value; }
		}
	
	}
}
	