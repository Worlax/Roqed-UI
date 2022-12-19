using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WindowFactory : MonoBehaviour
{
	[SerializeField] Transform content;
	[SerializeField] CourseWindow courseWindow;
	[SerializeField] SettingsWindow settingsWindow;
	[SerializeField] BugReportWindow bugReportWindow;

	[Inject] DiContainer diContainer;
	[Inject] DataBase dataBase;

	List<Window<Data>> activeWindows = new List<Window<Data>>();
	public IReadOnlyList<Window<Data>> ActiveWindows => activeWindows;

	// Events
	public Action<Window<Data>> OnWindowOpened;
	public Action<Window<Data>> OnWindowClosed;

	// Creation
	public void CreateCourseWindow(CourseData data) => CreateWindow(courseWindow, data);
	public void CreateSettingsWindow() => CreateWindow(settingsWindow, dataBase.settingsData);
	public void CreateBugReportWindow() => CreateWindow(bugReportWindow, dataBase.BugReportData);

	Window<T> CreateWindow<T>(Window<T> prefab, Data data) where T : Data
	{
		Window<T> window = diContainer.InstantiatePrefab(prefab, content).GetComponent<Window<T>>();
		window.UpdateData(data as T);

		window.OnClose += WindowClosed;
		activeWindows.Add(window as Window<Data>);
		OnWindowOpened?.Invoke(window as Window<Data>);

		return window;
	}

	// Events
	void WindowClosed<T>(Window<T> window) where T : Data
	{
		activeWindows.Remove(window as Window<Data>);
		OnWindowClosed?.Invoke(window as Window<Data>);
	}
}