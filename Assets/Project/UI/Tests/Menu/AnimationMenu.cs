using UnityEngine;

public class AnimationMenu : ToggleMenu
{
	AnimationData[] data;

	// Unity
	private void Start()
	{
		data = ActiveCourse.Value.AnimtaionsData;
		if (data == null) { Destroy(gameObject); }
	}

	// Events
	protected override void Toggled(bool value)
	{

	}
}