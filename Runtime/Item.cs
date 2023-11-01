using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foxthorne.FoxInventory
{
	[Serializable]
	public struct Item
	{
		public SO_ItemData itemData;
		public int Count { get; private set; }

		public int Add(int amount)
		{
			// Verify the amount
			if (amount < 1)
			{
				Debug.LogError("Invalid item amount " + amount);
				return -1;
			}

			int sum = Count + amount;
			// If the items fit in a stack
			if (sum <= itemData.maxStackSize)
			{
				Count = sum;
				return 0;
			}
			else // If the items don't fit
			{
				Count = itemData.maxStackSize;
				return sum - itemData.maxStackSize;
			}
		}
	}
}
