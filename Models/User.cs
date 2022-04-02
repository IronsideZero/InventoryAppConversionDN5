using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{

	/// <summary>
	/// For FinalProj
	/// @author bdavi
	/// </summary>
	[Serializable]
	public class User
	{

		private const long serialVersionUID = 1L;

		[Key]
		public string Email { get; set; }
		public bool Active { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
		public string RegistrationKey { get; set; }
		public string Salt { get; set; }
		public Company Company { get; set; }
		public Role Role { get; set; }

		public User()
		{
		}

		public User(string email)
		{
			this.Email = email;
		}

		public User(string email, bool active, string firstName, string lastName, string password, string salt, Company company, Role role)
		{
			this.Email = email;
			this.Active = active;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Password = password;
			this.Salt = salt;
			this.Company = company;
			this.Role = role;
		}




		public override int GetHashCode()
		{
			int hash = 0;
			hash += (!string.ReferenceEquals(Email, null) ? Email.GetHashCode() : 0);
			return hash;
		}

		public override bool Equals(object @object)
		{
			// TODO: Warning - this method won't work in the case the id fields are not set
			if (!(@object is User))
			{
				return false;
			}
			User other = (User) @object;
			if ((string.ReferenceEquals(this.Email, null) && !string.ReferenceEquals(other.Email, null)) || (!string.ReferenceEquals(this.Email, null) && !this.Email.Equals(other.Email)))
			{
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			return "Models.User[ email=" + Email + " ]";
		}

	}

}