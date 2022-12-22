using UnityEngine;
using Zenject;

public class PracticeMenu : ButtonMenu
{
	[Inject] SceneLoader sceneLoader;
	PracticeData data;

	// Unity
	private void Start()
	{
		data = ActiveCourse.Value.PracticeData;
		if (data == null) { Destroy(gameObject); }
	}

	// Events
	protected override void Clicked()
	{
		sceneLoader.LoadPracrice();
	}
}