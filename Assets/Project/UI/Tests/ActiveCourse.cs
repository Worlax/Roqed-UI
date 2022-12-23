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
<<<<<<< Updated upstream
			Scene activeScene = SceneManager.GetActiveScene();
			bool courseIsInUseOnScene = activeScene.name == "Practice" || activeScene.name == "Study";

			return courseIsInUseOnScene ? sceneLoader.LastLoadedCourse : null;
=======
			if (sceneLoader == null) Debug.Log("Scene loader rip");
			Scene activeScene = SceneManager.GetActiveScene();
			bool courseIsInUseOnScene = activeScene.name == "Practice" || activeScene.name == "Study";
			if (sceneLoader.LastLoadedCourse == null) Debug.Log("???2");
			//return courseIsInUseOnScene ? sceneLoader.LastLoadedCourse : null;
			return courseIsInUseOnScene ? sceneLoader.LastLoadedCourse : sceneLoader.LastLoadedCourse;
>>>>>>> Stashed changes
		}
	}
}