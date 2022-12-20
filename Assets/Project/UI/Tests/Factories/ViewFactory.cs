using UnityEngine;
using Zenject;

public class ViewFactory : MonoBehaviour
{
	[SerializeField] LicenseView licensePrefab;
	[SerializeField] CourseView coursePrefab;
	[SerializeField] AnimationView animationSmallPrefab;
	[SerializeField] AnimationView animationBigPrefab;

	[Inject] DiContainer diContainer;
	[Inject] DataBase dataBase;

	public enum AnimationType
	{
		Small,
		Big
	}

	public CourseView CreateCourse(CourseData data, Transform parent) => Create(coursePrefab, data, parent) as CourseView;
	public LicenseView CreateLicense(Transform parent) => Create(licensePrefab, dataBase.licenseData, parent) as LicenseView;
	public AnimationView CreateAnimation(AnimationData data, Transform parent, AnimationType type) => Create(GetAnimationPrefab(type), data, parent) as AnimationView;

	AnimationView GetAnimationPrefab(AnimationType type)
	{
		switch (type)
		{
			case AnimationType.Small: return animationSmallPrefab;
			case AnimationType.Big: return animationBigPrefab;
			default: return null;
		}
	}

	View<T> Create<T>(View<T> prefab, Data data, Transform parent) where T : Data
	{
		View<T> view = diContainer.InstantiatePrefab(prefab, parent).GetComponent<View<T>>();
		view.UpdateData(data as T);
		return view;
	}
}
