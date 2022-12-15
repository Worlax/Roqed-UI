using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class SettingsButton : MonoBehaviour
{
	[Inject] WindowFactory windowFactory;

	// Unity
	private void Start()
	{
		GetComponent<Button>().onClick.AddListener(Click);
	}

	// Events
	private void Click()
	{
		windowFactory.CreateSettingsWindow(FakeLoader.GetSettingsData());
	}
}
