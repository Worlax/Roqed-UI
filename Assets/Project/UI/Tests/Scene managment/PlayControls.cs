using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayControls : MonoBehaviour
{
	[SerializeField] Button loadMainMenu;
	[Inject] SceneLoader courseLoader;

	// Unity
	private void Start()
	{
		loadMainMenu.onClick.AddListener(LoadMainMenu);
	}

	// Events
	void LoadMainMenu()
	{
		courseLoader.LoadMainMenu();
	}
}
