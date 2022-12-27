using UnityEngine;

public class DescriptionMenu : ToggleMenu
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
