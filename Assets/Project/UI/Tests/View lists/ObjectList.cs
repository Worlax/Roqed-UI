using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectList : ViewListSynchronized<ObjectData>
{
	[Inject] ViewFactory viewFactory;
	[Inject] Database database;

	protected override List<IDataContainer<ObjectData>> CreateAllItems(Transform parent)
	{
		List<IDataContainer<ObjectData>> items = new List<IDataContainer<ObjectData>>();

		foreach (ObjectData data in database.ActiveCourse.ObjectsData)
		{
			items.Add(CreateItem(data, parent));
		}

		return items;
	}

	protected override IDataContainer<ObjectData> CreateItem(Data data, Transform parent)
	{
		return viewFactory.CreateObject(data as ObjectData, parent);
	}

	protected override bool NeededOnScene()
	{
		return database.ActiveCourse.ObjectsData != null;
	}
}
