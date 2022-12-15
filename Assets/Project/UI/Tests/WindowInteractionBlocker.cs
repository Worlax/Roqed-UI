using UnityEngine;
using Zenject;

public class WindowInteractionBlocker : MonoBehaviour
{
	[SerializeField] Transform body;
	[Inject] WindowFactory windowFactory;

	// Unity
	private void Start()
	{
		windowFactory.OnWindowOpened += _ => UpdateBlocker();
		windowFactory.OnWindowClosed += _ => UpdateBlocker();
	}

	// Events
	void UpdateBlocker()
	{
		int activeWindows = windowFactory.ActiveWindows.Count;

		body.gameObject.SetActive(activeWindows > 0);
		body.SetSiblingIndex(activeWindows - 1);
	}
}
