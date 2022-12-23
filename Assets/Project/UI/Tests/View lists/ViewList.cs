using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class ViewList : MonoBehaviour
{
	[SerializeField] Transform content;
	[SerializeField] string type;

	Dictionary<string, Transform> items = new Dictionary<string, Transform>();

	[SerializeField] bool synchronizable;
	static Dictionary<string, List<Data>> synchronizedLists = new Dictionary<string, List<Data>>();
	Toggle activeItem;

	void ToggleTests()
	{
		foreach (Transform item in content)
		{
			Toggle toggle = item.GetComponent<Toggle>();
			if (toggle == null) throw new Exception("List synchronization available only for items with 'toggle' component.");

			toggle.onValueChanged.AddListener(value => ItemToggleValueChanged(toggle, value));
		}
	}

	void ItemToggleValueChanged(Toggle item, bool value)
	{
		if (value)
		{
			activeItem = item;
		}
	}

	void Synchronize()
	{
		List<View<Data>> ourItems = GetAllItems().ToList();
		List<Data> synchronizedItems = synchronizedLists[type];

		SynchronizeSize(synchronizedItems, ref ourItems);
		SynchronizeData(synchronizedItems, ourItems);
	}

	void SynchronizeData(List<Data> synchronizedItems, List<View<Data>> ourItems)
	{
		if (synchronizedItems.Count != ourItems.Count())
		{
			SynchronizeSize(synchronizedItems, ref ourItems);
		}

		for (int i = 0; i < synchronizedItems.Count; ++i)
		{
			Data syncrhonizedItem = synchronizedItems[i];
			View<Data> ourItem = ourItems[i];

			if (syncrhonizedItem != ourItem.Data)
			{
				ourItem.UpdateData(syncrhonizedItem);
			}
		}
	}

	void SynchronizeSize(List<Data> synchronizedItems, ref List<View<Data>> ourItems)
	{
		int difference = synchronizedItems.Count - ourItems.Count;

		if (difference > 0)
		{
			for (int i = ourItems.Count - 1; difference > 0; --difference, --i)
			{
				View<Data> item = ourItems[i];

				ourItems.Remove(item);
				Destroy(item);
			}
		}
		else if (difference < 0)
		{
			for (int i = synchronizedItems.Count - 1; difference < 0; ++difference, --i)
			{
				ourItems.Add(CreateItem(synchronizedItems[i], content));
			}
		}
	}
	protected abstract View<Data> CreateItem(Data data, Transform parent);
	protected abstract List<View<Data>> CreateAllItems(Transform parent);

	void FillContent()
	{
		if (content == null) print("sheee");
		CreateAllItems(content);
	}

	List<View<Data>> GetAllItems()
	{
		List<View<Data>> items = new List<View<Data>>();

		foreach (Transform transform in content)
		{
			View<Data> view = transform.GetComponent<View<Data>>();
			if (view == null) throw new Exception("View list can't contain non-view items.");

			items.Add(view);
		}

		return items;
	}

	void FillSynchronizeList()
	{
		if (synchronizedLists[type] == null)
			{ return; }

		synchronizedLists[type] = GetAllItems().Select(x => x.Data).ToList();
	}

	// Unity
	protected virtual void Start()
	{
		gogogog.onClick.AddListener(Synchronize);
		FillContent();

		if (synchronizable)
		{
			FillSynchronizeList();
		}
	}

	[SerializeField] Button gogogog;

	protected virtual void OnEnable()
	{
		if (synchronizable)
		{
			//Synchronize();
		}
	}
}