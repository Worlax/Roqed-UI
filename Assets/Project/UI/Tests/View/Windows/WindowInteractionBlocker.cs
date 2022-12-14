using System.Linq;
using UnityEngine;

public class WindowInteractionBlocker : MonoBehaviour
{
	[SerializeField] Transform body;

	// Unity
	private void Start()
	{
		Window.OnCreated += UpdateBlocker;
		Window.OnClosed += UpdateBlocker;
	}

	// Events
	void UpdateBlocker(Window window)
	{
		int activeWindows = Window.ActiveWindows.Count();

		body.gameObject.SetActive(activeWindows > 0);
		body.SetSiblingIndex(activeWindows - 1);
	}
}
