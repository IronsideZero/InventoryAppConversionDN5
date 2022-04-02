using System;
using System.Collections.Generic;

namespace Models
{
	[Serializable]
    public class Category
    {
		private const long serialVersionUID = 1L;
		public int? CategoryId { get; set; }
		public string CategoryName { get; set; }
		public IList<Item> ItemList { get; set; }

		public Category()
		{
		}

		//public Category(int? categoryId)
		//{
		//	this.CategoryId = categoryId;
		//}

		public Category(int categoryId, string categoryName)
		{
			this.CategoryId = categoryId;
			this.CategoryName = categoryName;
			this.ItemList = new List<Item>();
		}


		public override int GetHashCode()
		{
			int hash = 0;
			hash += (CategoryId != null ? CategoryId.GetHashCode() : 0);
			return hash;
		}

		public override bool Equals(object @object)
		{
			// TODO: Warning - this method won't work in the case the id fields are not set
			if (!(@object is Category))
			{
				return false;
			}
			Category other = (Category)@object;
			if ((this.CategoryId == null && other.CategoryId != null) || (this.CategoryId != null && !this.CategoryId.Equals(other.CategoryId)))
			{
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			return "Models.Category[ categoryId=" + CategoryId + " ]";
		}
	}
}