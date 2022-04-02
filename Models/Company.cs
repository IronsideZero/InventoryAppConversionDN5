using System;
using System.Collections.Generic;

namespace Models
{

	/// <summary>
	/// For FinalProj
	/// @author bdavi
	/// </summary>
	[Serializable]
	public class Company
	{

		private const long serialVersionUID = 1L;

		public int? CompanyId { get; set; }
		public string CompanyName { get; set;}
		public IList<User> UserList { get; set; }

		public Company()
		{
		}

		public Company(int? companyId)
		{
			this.CompanyId = companyId;
		}

		public Company(int? companyId, string companyName)
		{
			this.CompanyId = companyId;
			this.CompanyName = companyName;
			this.UserList = new List<User>();
		}


		public override int GetHashCode()
		{
			int hash = 0;
			hash += (CompanyId != null ? CompanyId.GetHashCode() : 0);
			return hash;
		}

		public override bool Equals(object @object)
		{
			// TODO: Warning - this method won't work in the case the id fields are not set
			if (!(@object is Company))
			{
				return false;
			}
			Company other = (Company) @object;
			if ((this.CompanyId == null && other.CompanyId != null) || (this.CompanyId != null && !this.CompanyId.Equals(other.CompanyId)))
			{
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			return "Models.Company[ CompanyId=" + CompanyId + " ]";
		}

	}

}