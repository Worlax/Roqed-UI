using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Database
{
	[Inject] SceneLoader sceneLoader;

	public SettingsData SettingsData => FakeDataLoader.GetSettings();
	public LicenseData LicenseData => FakeDataLoader.GetLicense();
	public BugReportData BugReportData => FakeDataLoader.GetBugReport();

	public CourseData ActiveCourse
	{
		get
		{
			Scene activeScene = SceneManager.GetActiveScene();
			bool courseIsInUseOnScene = activeScene.name == "Practice" || activeScene.name == "Study";

			return courseIsInUseOnScene ? sceneLoader.LastLoadedCourse : null;
		}
	}
}
