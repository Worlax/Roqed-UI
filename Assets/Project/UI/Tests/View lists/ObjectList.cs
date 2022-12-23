<<<<<<< Updated upstream
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(ToggleGroup))]
public class ObjectList : MonoBehaviour
{
	[SerializeField] Transform content;
	[Inject] ViewFactory viewFactory;

	void FillContent()
	{
		ObjectData[] objectData = ActiveCourse.Value.ObjectsData;
		if (objectData == null) { Destroy(gameObject); return; }

		foreach (ObjectData data in objectData)
		{
			ObjectView item = viewFactory.CreateObject(data, content);
			item.GetComponent<Toggle>().group = GetComponent<ToggleGroup>();
		}
	}

	// Unity
	private void Start()
	{
		FillContent();
	}
}
=======
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectList : ViewListSynchronized<ObjectData>
{
	[Inject] ViewFactory viewFactory;

	protected override List<IDataContainer<ObjectData>> CreateAllItems(Transform parent)
	{
		List<IDataContainer<ObjectData>> items = new List<IDataContainer<ObjectData>>();

		if (ActiveCourse.Value == null) print(":(");
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
>>>>>>> Stashed changes
