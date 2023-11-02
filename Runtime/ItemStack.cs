using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foxthorne.FoxInventory
{
	[Serializable]
	public struct ItemStack
	{
		public ItemStack(SO_ItemData itemData, int count)
		{
			ItemData = itemData;
			Count = count;
		}

		public SO_ItemData ItemData { get; }
		public int Count { get; private set; }

		/// <summary>
		/// Adds <paramref name="amount"/> to this item stack.
		/// </summary>
		/// <param name="amount"></param>
		/// <returns>The number of excess items, if they did not all fit in this stack.</returns>
		public int AddItems(int amount)
		{
			// Verify the amount
			if (amount < 1)
			{
				Debug.LogError("Invalid item amount " + amount);
				return -1;
			}

			int sum = Count + amount;
			// If the items fit in a stack
			if (sum <= ItemData.maxStackSize)
			{
				Count = sum;
				return 0;
			}
			else // If the items don't fit
			{
				Count = ItemData.maxStackSize;
				return sum - ItemData.maxStackSize;
			}
		}

		/// <summary>
		/// Adds two stacks together, returning the excess items.
		/// </summary>
		/// <param name="otherItems"></param>
		/// <returns></returns>
		public ItemStack CombineStacks(ItemStack otherItems)
		{
			if (otherItems.ItemData != ItemData)
			{
				throw new ArgumentException("Items of two different types cannot be combined");
			}

			int sum = Count + otherItems.Count;
			// If the items fit in one stack
			if (sum <= ItemData.maxStackSize)
			{
				Count = sum;
				return new ItemStack(ItemData, 0);
			}
			else // If not all of the items fit
			{
				Count = ItemData.maxStackSize;
				return new ItemStack(ItemData, sum - ItemData.maxStackSize);
			}
		}


	}
}
