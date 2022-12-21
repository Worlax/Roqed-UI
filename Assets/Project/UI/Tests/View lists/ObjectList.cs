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
		foreach (ObjectData data in FakeDataLoader.GetAllObjectData())
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
