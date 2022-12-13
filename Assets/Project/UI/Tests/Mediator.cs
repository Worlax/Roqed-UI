using UnityEngine;

public class Mediator : Singleton<Mediator>
{
	[SerializeField] WindowFactory popupFactory;

	public void CreateCourseViewBigWindow(CourseData initData) => popupFactory.CreateWindow(popupFactory.CourseBigPreviewPrefab, initData);
	public void CreateSettingsWindow(SettingsData initData) => popupFactory.CreateWindow(popupFactory.SettingsView, initData);
}
