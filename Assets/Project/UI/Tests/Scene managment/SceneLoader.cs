using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	[SerializeField] Scene PlayScene;

	const string MAIN_MENU = "Main menu";
	const string PLAY = "Play";

	public void LoadMainMenu()
	{
		SceneManager.LoadScene(MAIN_MENU);
	}

	public void LoadCourse(CourseData data)
	{
		SceneManager.LoadScene(PLAY);
	}
}
