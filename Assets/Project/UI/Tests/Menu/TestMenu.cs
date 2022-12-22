using UnityEngine;

public class TestMenu : ToggleMenu
{
	TestData[] data;

	// Unity
	private void Start()
	{
		data = ActiveCourse.Value.TestsData;
		if (data == null) { Destroy(gameObject); }
	}

	// Events
	protected override void Toggled(bool value)
	{

	}
}