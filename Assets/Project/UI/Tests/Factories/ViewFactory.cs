using UnityEngine;
using Zenject;

public class ViewFactory : MonoBehaviour
{
	[SerializeField] CourseView courseView;
	[Inject] DiContainer diContainer;

	public CourseView CreateCourse(CourseData data, Transform parent) => Create(courseView, data, parent) as CourseView;

	View<T> Create<T>(View<T> prefab, Data data, Transform parent) where T : Data
	{
		View<T> view = diContainer.InstantiatePrefab(prefab, parent).GetComponent<View<T>>();
		view.UpdateData(data as T);
		return view;
	}
}
