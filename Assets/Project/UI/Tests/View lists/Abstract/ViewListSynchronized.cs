using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewListSynchronized<T> : ViewList<T> where T : Data
{
	[SerializeField] [HideInInspector] bool uniqueSynchronization;
	[SerializeField] [HideInInspector] [Min(0)] int uniqueSynchronizationId;

	int synchrionizationId;
	static Dictionary<int, List<T>> synchronizedItemsDictonary = new Dictionary<int, List<T>>();

	void Synchronize()
	{
		List<T> synchronizedItems = synchronizedItemsDictonary[synchrionizationId];
		List<IDataContainer<T>> ourItems = GetContentItems();

		SynchronizeSize(synchronizedItems, ref ourItems);
		SynchronizeData(synchronizedItems, ourItems);
	}

	void SynchronizeSize(List<T> synchronizedItems, ref List<IDataContainer<T>> ourItems)
	{
		int lackOfItems = synchronizedItems.Count - ourItems.Count;

		if (lackOfItems > 0)
		{
			for (int i = 0; i < lackOfItems; ++i)
			{
				int synchIndex = synchronizedItems.Count() - 1 - i;
				ourItems.Add(CreateItem(synchronizedItems[synchIndex], content));
			}
		}
		else if (lackOfItems < 0)
		{
			for (int i = 0; i > lackOfItems; --i)
			{
				int itemIndex = ourItems.Count() - 1;
				IDataContainer<T> item = ourItems[itemIndex];
				ourItems.Remove(item);
				Destroy(item.GetGameObject());
			}
		}
	}

	void SynchronizeData(List<T> synchronizedItems, List<IDataContainer<T>> ourItems)
	{
		if (synchronizedItems.Count != ourItems.Count) throw new Exception("Data size is not synchronized.");

		for (int i = 0; i < synchronizedItems.Count; ++i)
		{
			T syncrhonizedItem = synchronizedItems[i];
			IDataContainer<T> ourItem = ourItems[i];

			if (syncrhonizedItem != ourItem.Data)
			{
				ourItem.UpdateData(syncrhonizedItem);
			}
		}
	}

	void FillSynchronizeList()
	{
		synchronizedItemsDictonary[synchrionizationId] = GetContentItems().Select(x => x.Data).ToList();
	}

	// Unity
	protected override void Awake()
	{
		synchrionizationId = uniqueSynchronization ? uniqueSynchronizationId : -1;

		FillContent();

		if (!synchronizedItemsDictonary.ContainsKey(synchrionizationId))
		{
			FillSynchronizeList();
		}
	}

	protected virtual void OnEnable()
	{
		Synchronize();
	}
}