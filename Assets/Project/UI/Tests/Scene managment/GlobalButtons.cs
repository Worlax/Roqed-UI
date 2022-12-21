using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GlobalButtons : MonoBehaviour
{
	[SerializeField] Button bugReport;
	[SerializeField] Button hide;
	[SerializeField] Button scale;
	[SerializeField] Button close;

	[Inject] WindowFactory windowFactory;
	[Inject] SceneLoader sceneLoader;

#if UNITY_STANDALONE_WIN
	[DllImport("user32.dll")]
	private static extern IntPtr GetActiveWindow();
	[DllImport("user32.dll")]
	static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
#endif

	// Unity
	private void Start()
	{
		close.onClick.AddListener(Close);
		hide.onClick.AddListener(Hide);
		scale.onClick.AddListener(Scale);
		bugReport.onClick.AddListener(BugReport);
	}

	// Events
	void Close()
	{
		if (SceneManager.GetActiveScene().name == "Main menu")
		{
			Application.Quit();
		}
		else
		{
			sceneLoader.LoadMainMenu();
		}
	}

	void Hide()
	{
		if (Application.platform == RuntimePlatform.WindowsPlayer)
		{
			ShowWindow(GetActiveWindow(), 2);
		}
	}

	void Scale()
	{
		Screen.fullScreen = !Screen.fullScreen;
	}

	void BugReport()
	{
		windowFactory.CreateBugReport();
	}
}
