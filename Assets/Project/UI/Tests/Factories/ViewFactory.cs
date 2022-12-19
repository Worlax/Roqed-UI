using UnityEngine;
using Zenject;

public class ViewFactory : MonoBehaviour
{
	[SerializeField] CourseView courseView;
	[SerializeField] LicenseView licenseView;

	[Inject] DiContainer diContainer;
	[Inject] DataBase dataBase;

	public CourseView CreateCourseView(CourseData data, Transform parent) => Create(courseView, data, parent) as CourseView;
	public LicenseView CreateLicenseView(Transform parent) => Create(licenseView, dataBase.licenseData, parent) as LicenseView;

	View<T> Create<T>(View<T> prefab, Data data, Transform parent) where T : Data
	{
		View<T> view = diContainer.InstantiatePrefab(prefab, parent).GetComponent<View<T>>();
		view.UpdateData(data as T);
		return view;
	}
}
