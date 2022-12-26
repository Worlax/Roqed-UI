using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public static class ActiveCourse
{
	public static SceneLoader sceneLoader;

	public static CourseData Value
	{
		get
		{
			Scene activeScene = SceneManager.GetActiveScene();
			bool courseIsInUseOnScene = activeScene.name == "Practice" || activeScene.name == "Study";

			Debug.Log("TODO");
			//return courseIsInUseOnScene ? sceneLoader.LastLoadedCourse : null;
			return courseIsInUseOnScene ? sceneLoader.LastLoadedCourse : sceneLoader.LastLoadedCourse;
		}
	}
}