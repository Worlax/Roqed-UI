using UnityEngine;
using Zenject;

public class WindowInteractionBlocker : MonoBehaviour
{
	[SerializeField] Transform body;
	[Inject] WindowFactory windowFactory;

	void UpdateBlocker()
	{
		int activeWindows = windowFactory.ActiveWindows.Count;

		body.gameObject.SetActive(activeWindows > 0);
		body.SetSiblingIndex(activeWindows - 1);
	}

	// Unity
	private void OnEnable()
	{
		windowFactory.OnWindowOpened += WindowStateChanged;
		windowFactory.OnWindowClosed += WindowStateChanged;
	}

	private void OnDisable()
	{
		windowFactory.OnWindowOpened -= WindowStateChanged;
		windowFactory.OnWindowClosed -= WindowStateChanged;
	}

	// Events
	void WindowStateChanged(Window<Data> window) => UpdateBlocker();
}
