using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public static class PlayFromFristScene
{
	const string menuName = "Edit/Play from first scene";

	static bool playFromFirstScene
	{
		get { return EditorPrefs.HasKey(menuName) && EditorPrefs.GetBool(menuName); }
		set { EditorPrefs.SetBool(menuName, value); }
	}

	[MenuItem(menuName, false, 175)]
	static void PlayFromFirstSceneCheckMenu()
	{
		playFromFirstScene = !playFromFirstScene;
		UnityEditor.Menu.SetChecked(menuName, playFromFirstScene);
	}

	// The menu won't be gray out, we use this validate method for update check state
	[MenuItem(menuName, true, 175)]
	static bool PlayFromFirstSceneCheckMenuValidate()
	{
		UnityEditor.Menu.SetChecked(menuName, playFromFirstScene);
		return true;
	}

	// This method is called before any Awake. It's the perfect callback for this feature
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	static void LoadFirstSceneAtGameBegins()
	{
		if (!playFromFirstScene)
			return;

		if (EditorBuildSettings.scenes.Length == 0)
		{
			Debug.LogWarning("The scene build list is empty.");
			return;
		}

		foreach (GameObject go in Object.FindObjectsOfType<GameObject>())
			go.SetActive(false);

		SceneManager.LoadScene(0);
	}

	static void ShowNotifyOrLog(string msg)
	{
		if (Resources.FindObjectsOfTypeAll<SceneView>().Length > 0)
			EditorWindow.GetWindow<SceneView>().ShowNotification(new GUIContent(msg));
		else
			Debug.Log(msg); // When there's no scene view opened, we just print a log
	}
}