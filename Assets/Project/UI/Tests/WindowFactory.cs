using System.Collections.Generic;
using UnityEngine;

public class WindowFactory : MonoBehaviour
{
	[SerializeField] Transform interactionBlock;

	[field: SerializeField] public CourseViewBig CourseBigPreviewPrefab { get; private set; }
	[field: SerializeField] public SettingsView SettingsView { get; private set; }

	Stack<Window> openedWindows = new Stack<Window>();

	public void CreateWindow<T>(Window prefab, T initData)
	{
		Window window = Instantiate(prefab, transform);
		InitializeWindow(window, initData);
		UpdateInteractionBlock();
	}

	private void InitializeWindow<T>(Window window, T initData)
	{
		window.Init(initData);

		window.transform.SetAsLastSibling();
		openedWindows.Push(window);
		window.OnClosed += WindowClosed;
	}

	void UpdateInteractionBlock()
	{
		if (openedWindows.Count > 0)
		{
			interactionBlock.gameObject.SetActive(true);
			interactionBlock.SetSiblingIndex(openedWindows.Count - 1);
		}
		else
		{
			interactionBlock.gameObject.SetActive(false);
		}
	}

	// Events
	void WindowClosed()
	{
		openedWindows.Pop();
		UpdateInteractionBlock();
	}
}
