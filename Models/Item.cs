using System;

namespace Models
{

	/// <summary>
	/// For FinalProj
	/// @author bdavi
	/// </summary>
	[Serializable]
	public class Item
	{

		private const long serialVersionUID = 1L;
		public int ItemId { get; set; }
		public string ItemName { get; set; }
		public double Price { get; set; }
		public Category Category { get; set; }
		public User Owner { get; set; }

		public Item()
		{
		}

		public Item(int itemId)
		{
			this.ItemId = itemId;
		}

		public Item(int itemId, string itemName, double price, Category category, User owner)
		{
			this.ItemId = itemId;
			this.ItemName = itemName;
			this.Price = price;
			this.Category = category;
			this.Owner = owner;
		}

		
		public override int GetHashCode()
		{
			int hash = 0;
			hash += (ItemId != null ? ItemId.GetHashCode() : 0);
			return hash;
		}

		public override bool Equals(object @object)
		{
			// TODO: Warning - this method won't work in the case the id fields are not set
			if (!(@object is Item))
			{
				return false;
			}
			Item other = (Item) @object;
			if ((this.ItemId == null && other.ItemId != null) || (this.ItemId != null && !this.ItemId.Equals(other.ItemId)))
			{
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			return "Models.Item[ ItemId=" + ItemId + " ]";
		}

	}

}