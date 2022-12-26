using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectList : ViewListSynchronized<ObjectData>
{
	[Inject] ViewFactory viewFactory;

	protected override List<IDataContainer<ObjectData>> CreateAllItems(Transform parent)
	{
		List<IDataContainer<ObjectData>> items = new List<IDataContainer<ObjectData>>();

		foreach (ObjectData data in ActiveCourse.Value.ObjectsData)
		{
			items.Add(CreateItem(data, parent));
		}

		return items;
	}

	protected override IDataContainer<ObjectData> CreateItem(Data data, Transform parent)
	{
		return viewFactory.CreateObject(data as ObjectData, parent);
	}
}
