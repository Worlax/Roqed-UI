using UnityEngine;
using UnityEngine.SceneManagement;

public class CourseLoader : MonoBehaviour
{
	[SerializeField] Scene PlayScene;

	public void Load(CourseData data)
	{
		SceneManager.LoadScene((int)Scenes.Play);
	}
}
