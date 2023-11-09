using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foxthorne.FoxInventory
{
	public class Inventory : MonoBehaviour
	{
		public ItemStack[] contents;

		public void MoveItems(SO_ItemData item, int amount, Inventory destination)
		{

		}

		/// <summary>
		/// Delete <paramref name="amount"/> of <paramref name="item"/> from this inventory.
		/// </summary>
		/// <param name="item">The type of item to delete.</param>
		/// <param name="amount">How many of the item to delete.</param>
		/// <param name="mustHaveAmount">If true, the inventory must have at least <paramref name="amount"/> for any items to be deleted.</param>
		public bool ConsumeItems(SO_ItemData item, int amount, bool mustHaveAmount = true)
		{
			if (mustHaveAmount && !HasItems(item, amount)) return false;

			foreach (ItemStack s in contents)
			{
				if (amount <= 0) return true;

				if (s.ItemData == item)
				{
					amount = s.RemoveItems(amount);
				}
			}

			return false;
		}

		#region Checker methods
		public bool HasItem(SO_ItemData item)
		{
			foreach (ItemStack s in contents)
			{
				if (s.ItemData == item)
				{
					return true;
				}
			}

			return false;
		}

		public bool HasItems(SO_ItemData item, int count)
		{
			if (GetItemCount(item) >= count)
			{
				return true;
			}

			return false;
		}

		public int GetItemCount(SO_ItemData item)
		{
			int sum = 0;
			foreach (ItemStack s in contents)
			{
				if (s.ItemData == item)
				{
					sum += s.Count;
				}
			}

			return sum;
		}
		#endregion
	}
}
