using UnityEngine;

public class InteractionMenu : ToggleMenu
{
	ObjectData[] data;

	// Unity
	private void Start()
	{
		data = ActiveCourse.Value.ObjectsData;
		if (data == null) { Destroy(gameObject); }
	}

	// Events
	protected override void Toggled(bool value)
	{

	}
}