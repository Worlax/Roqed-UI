using UnityEngine;
using Zenject;

public class PracticeMenu : ButtonMenu
{
	[Inject] SceneLoader sceneLoader;

	protected override bool NeededOnScene()
	{
		return database.ActiveCourse.PracticeData != null;
	}

	// Events
	protected override void Clicked()
	{
		sceneLoader.LoadPracrice();
	}
}