using UnityEngine;

public class ViewFactory : MonoBehaviour
{
	[SerializeField] Transform windowParent;

	[SerializeField] public CourseView CourseView;
	[SerializeField] public CourseWindow CourseWindow;
	[SerializeField] public SettingsWindow SettingsWindow;

	public View CreateCourseView(ICourseData data, Transform parent) => CreateView(CourseView, data, parent);
	public void CreateCourseWindow(ICourseData data) => CreateWindow(CourseWindow, data);
	public void CreateSettingsWindow(ISettingsData data) => CreateWindow(SettingsWindow, data);

	View CreateView(View prefab, IData data, Transform parent)
	{
		View view = Instantiate(prefab, parent);
		view.UpdateData(data);

		return view;
	}

	Window CreateWindow(Window prefab, IData data)
	{
		Window window = Instantiate(prefab, windowParent);
		window.UpdateData(data);

		return window;
	}
}
