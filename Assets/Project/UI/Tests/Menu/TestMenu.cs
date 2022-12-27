using UnityEngine;
using Zenject;

public class TestMenu : ToggleMenu
{
	protected override bool NeededOnScene()
	{
		return database.ActiveCourse.TestsData != null;
	}

	// Events
	protected override void Toggled(bool value)
	{

	}
}