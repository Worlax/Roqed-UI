using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
	[Inject] SceneLoader sceneLoader;

	// Unity
	private void Start()
	{
		sceneLoader.LoadMainMenu();
	}
}
