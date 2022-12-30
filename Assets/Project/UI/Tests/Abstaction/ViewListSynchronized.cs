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

	static bool synchronizing;
	int synchronizationId;
	static Dictionary<int, List<T>> synchronizedDataDictionary = new Dictionary<int, List<T>>();
	static Dictionary<int, List<bool>> synchronizedTogglesDictionary = new Dictionary<int, List<bool>>();

	public static event Action<T> OnNewItemToggled;

	public T GetActiveItem()
	{
		return GetContentItems().First(x => x.GetGameObject().GetComponent<Toggle>().isOn).Data;
	}

	static void SynchronizeAll()
	{
		synchronizing = true;

		List<ViewListSynchronized<T>> allLists = FindObjectsOfType<ViewListSynchronized<T>>().ToList();
		foreach (ViewListSynchronized<T> list in allLists)
		{
			list.Synchronize();
		}

		synchronizing = false;
	}

	void Synchronize()
	{
		print("Synchronizing " + name);
		List<T> synchronizedData = synchronizedDataDictionary[synchronizationId];
		List<IDataContainer<T>> ourItems = GetContentItems();
		List<Toggle> ourToggles = GetContentToggles();

		SynchronizeSize(synchronizedData, ref ourItems);
		SynchronizeData(synchronizedData, ourItems);

		if(synchronizeToggle)
		{
			List<bool> synchronizedToggles = synchronizedTogglesDictionary[synchronizationId];
			SynchronizeToggles(synchronizedToggles, ourToggles);
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

	void SynchronizeToggles(List<bool> synchronizedToggles, List<Toggle> ourToggles)
	{
		if (synchronizedToggles.Count() != ourToggles.Count) throw new Exception("Toggles size is not syncrhonized.");

		for (int i = 0; i < synchronizedToggles.Count; ++i)
		{
			bool synchronizedItem = synchronizedToggles[i];
			ourToggles[i].isOn = synchronizedItem;
		}
	}

	void SaveDataState()
	{
		print("Saving data " + name);
		synchronizedDataDictionary[synchronizationId] = GetContentItems().Select(x => x.Data).ToList();
	}

	void SaveTogglesState()
	{
		print("Saving toggle " + name);
		synchronizedTogglesDictionary[synchronizationId] = GetContentItems()
			.Select(x => x.GetGameObject()
			.GetComponent<Toggle>().isOn)
			.ToList();
	}

	void AddTogglesToToggleGroup()
	{
		ToggleGroup toggleGroup = GetComponent<ToggleGroup>();

		foreach (IDataContainer<T> item in GetContentItems())
		{
			item.GetGameObject()
				.GetComponent<Toggle>()
				.group = toggleGroup;
		}
	}

	void SubscribeForToggleEvents()
	{
		foreach (IDataContainer<T> item in GetContentItems())
		{
			Toggle toggle = item.GetGameObject().GetComponent<Toggle>();
			toggle.onValueChanged.AddListener(value => ToggleValueChanged(item.Data, value));
		}
	}

	List<Toggle> GetContentToggles()
	{
		return GetContentItems().Select(x => x.GetGameObject().GetComponent<Toggle>()).ToList();
	}

	// Unity
	protected override void Awake()
	{
		base.Awake();

		synchronizationId = uniqueSynchronization ? uniqueSynchronizationId : -1;

		if (!synchronizedDataDictionary.ContainsKey(synchronizationId))
		{
			SaveDataState();
			if (synchronizeToggle) SaveTogglesState();
		}

		if (synchronizeToggle)
		{
			AddTogglesToToggleGroup();
			SubscribeForToggleEvents();
		}
	}

	protected virtual void OnEnable()
	{
		Synchronize();
	}

	// Evets
	void ToggleValueChanged(T data, bool value)
	{
		if (!synchronizing)
		{
			if (value) { OnNewItemToggled?.Invoke(data); }

			SaveDataState();
			if (synchronizeToggle) SaveTogglesState();
			SynchronizeAll();
		}
	}
}