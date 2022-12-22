using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public CourseData LastLoadedCourse { get; private set; }

	const string MAIN_MENU = "Main menu";
	const string STUDY = "Study";
	const string PRACTICE = "Practice";

	private void Start()
	{
		ActiveCourse.sceneLoader = this;
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene(MAIN_MENU);
	}

	public void LoadCourse(CourseData data)
	{
		string objects = data.ObjectsData != null ? "<color=green>on</color>" : "<color=red>Off</color>";
		string animations = data.AnimtaionsData != null ? "<color=green>on</color>" : "<color=red>Off</color>";
		string practice = data.PracticeData != null ? "<color=green>on</color>" : "<color=red>Off</color>";
		string tests = data.TestsData != null ? "<color=green>on</color>" : "<color=red>Off</color>";

		print($"objects: {objects}");
		print($"animations: {animations}");
		print($"practice: {practice}");
		print($"tests: {tests}");

		//

		LastLoadedCourse = data;
		SceneManager.LoadScene(STUDY);
	}

	public void LoadPracrice()
	{
		SceneManager.LoadScene(PRACTICE);
	}
}
