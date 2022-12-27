using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ViewListSynchronized<T> : ViewList<T> where T : Data
{
	[SerializeField] [HideInInspector] bool uniqueSynchronization;
	[SerializeField] [HideInInspector] [Min(0)] int uniqueSynchronizationId;
	[SerializeField] bool synchronizeToggle = true;

	int synchronizationId;
	static Dictionary<int, List<T>> synchronizedData = new Dictionary<int, List<T>>();
	static Dictionary<int, List<bool>> synchronizedToggle = new Dictionary<int, List<bool>>();

	static event Action<ViewListSynchronized<T>> OnSynchronizeEveryoneButOne;

	void Synchronize()
	{
		print("Synchronizing " + name);
		List<T> synchronizedData = ViewListSynchronized<T>.synchronizedData[synchronizationId];
		List<IDataContainer<T>> ourItems = GetContentItems();

		SynchronizeSize(synchronizedData, ref ourItems);
		SynchronizeData(synchronizedData, ourItems);

		if(synchronizeToggle)
		{
			List<bool> synchronizedToggles = synchronizedToggle[synchronizationId];
			SynchronizeToggle(synchronizedToggles, ourItems);
		}
	}

	void SynchronizeSize(List<T> synchronizedData, ref List<IDataContainer<T>> ourItems)
	{
		int lackOfItems = synchronizedData.Count - ourItems.Count;

		if (lackOfItems > 0)
		{
			for (int i = 0; i < lackOfItems; ++i)
			{
				int synchIndex = synchronizedData.Count() - 1 - i;
				ourItems.Add(CreateItem(synchronizedData[synchIndex], content));
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

	void SynchronizeData(List<T> synchronizedData, List<IDataContainer<T>> ourItems)
	{
		if (synchronizedData.Count != ourItems.Count) throw new Exception("Data size is not synchronized.");

		for (int i = 0; i < synchronizedData.Count; ++i)
		{
			T syncrhonizedItem = synchronizedData[i];
			IDataContainer<T> ourItem = ourItems[i];

			if (syncrhonizedItem != ourItem.Data)
			{
				ourItem.UpdateData(syncrhonizedItem);
			}
		}
	}

	void SynchronizeToggle(List<bool> synchronizedToggles, List<IDataContainer<T>> ourItems)
	{
		if (synchronizedToggles.Count() != ourItems.Count) throw new Exception("Toggles size is not syncrhonized.");

		for (int i = 0; i < synchronizedToggles.Count; ++i)
		{
			bool synchronizedItem = synchronizedToggles[i];
			Toggle ourItem = ourItems[i].GetGameObject().GetComponent<Toggle>();
			if (ourItem == null) throw new Exception("Item have no toggle component to synchronize.");

			if (synchronizedItem != ourItem.isOn)
			{
				ourItem.isOn = synchronizedItem;
			}
		}
	}

	void SaveDataState()
	{
		print("Saving data " + name);
		synchronizedData[synchronizationId] = GetContentItems().Select(x => x.Data).ToList();
	}

	void SaveTogglesState()
	{
		print("Saving toggle " + name);
		synchronizedToggle[synchronizationId] = GetContentItems()
			.Select(x => x.GetGameObject()
			.GetComponent<Toggle>().isOn)
			.ToList();
	}

	// Unity
	protected override void Awake()
	{
		base.Awake();

		synchronizationId = uniqueSynchronization ? uniqueSynchronizationId : -1;

		if (!synchronizedData.ContainsKey(synchronizationId))
		{
			SaveDataState();
			if (synchronizeToggle) SaveTogglesState();
		}
	}

	protected virtual void Start()
	{
		OnSynchronizeEveryoneButOne += SynchronizeEveryoneButOne;

		if (synchronizeToggle)
		{
			foreach (IDataContainer<T> item in GetContentItems())
			{
				item.GetGameObject()
					.GetComponent<Toggle>()
					.onValueChanged
					.AddListener(_ => SaveMyStateAndSynchronizeEveryoneElse());
			}
		}
	}

	protected virtual void OnEnable()
	{
		Synchronize();
	}

	// Evets
	void SaveMyStateAndSynchronizeEveryoneElse()
	{
		SaveDataState();
		if (synchronizeToggle) SaveTogglesState();

		OnSynchronizeEveryoneButOne?.Invoke(this);
	}

	void SynchronizeEveryoneButOne(ViewListSynchronized<T> butOne)
	{
		if (this != butOne)
		{
			Synchronize();
		}
		else
		{
			print("Ignore me " + name);
		}
	}
}