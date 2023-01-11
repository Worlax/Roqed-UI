using UnityEngine;

public class InteractionMenu : ToggleMenu
{
	protected override bool NeededOnScene()
	{
		return database.ActiveCourse.ObjectsData != null;
	}

	// Events
	protected override void Toggled(bool value)
	{

	}
}