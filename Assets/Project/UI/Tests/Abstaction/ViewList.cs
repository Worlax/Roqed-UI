using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewList<T> : MonoBehaviour where T : Data
{
	[SerializeField] protected Transform content;

	protected abstract IDataContainer<T> CreateItem(Data data, Transform parent);
	protected abstract List<IDataContainer<T>> CreateAllItems(Transform parent);
	protected abstract bool NeededOnScene();

	public bool Doomed { get; private set; }
	public List<IDataContainer<T>> Items { get; private set; } = new List<IDataContainer<T>>();

	protected void FillContent()
	{
		DeleteContentItems();
		Items = CreateAllItems(content);
	}

	protected List<IDataContainer<T>> GetContentItems()
	{
		List<IDataContainer<T>> items = new List<IDataContainer<T>>();

		foreach (Transform transform in content)
		{
			IDataContainer<T> view = transform.GetComponent<IDataContainer<T>>();
			if (view == null) throw new Exception("View list can't contain non-view items.");

			items.Add(view);
		}

		return items;
	}

	protected void DeleteContentItems()
	{
		foreach (GameObject item in content)
		{
			Destroy(item);
		}
	}

	// Unity
	protected virtual void Awake()
	{
		if (!NeededOnScene()) { Doomed = true; Destroy(gameObject); return; }

		FillContent();
	}
}