using System;
using System.Collections.Generic;

namespace Models
{

	/// <summary>
	/// For FinalProj
	/// @author bdavi
	/// </summary>
	[Serializable]
	public class Role
	{

		private const long serialVersionUID = 1L;

		public int RoleId { get; set; }
		public string RoleName { get; set; }
		public IList<User> UserList { get; set; }

		public Role()
		{
		}

		public Role(int roleId)
		{
			this.RoleId = roleId;
		}

		public Role(int roleId, string roleName)
		{
			this.RoleId = roleId;
			this.RoleName = roleName;
			this.UserList = new List<User>();
		}


		public override int GetHashCode()
		{
			int hash = 0;
			hash += (RoleId != null ? RoleId.GetHashCode() : 0);
			return hash;
		}

		public override bool Equals(object @object)
		{
			// TODO: Warning - this method won't work in the case the id fields are not set
			if (!(@object is Role))
			{
				return false;
			}
			Role other = (Role) @object;
			if ((this.RoleId == null && other.RoleId != null) || (this.RoleId != null && !this.RoleId.Equals(other.RoleId)))
			{
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			return "Models.Role[ roleId=" + RoleId + " ]";
		}

	}

}