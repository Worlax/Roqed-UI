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
