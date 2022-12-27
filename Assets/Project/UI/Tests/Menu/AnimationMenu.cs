using UnityEngine;

public class AnimationMenu : ToggleMenu
{
	protected override bool NeededOnScene()
	{
		return database.ActiveCourse.AnimtaionsData != null;
	}

	// Events
	protected override void Toggled(bool value)
	{
		
	}
}