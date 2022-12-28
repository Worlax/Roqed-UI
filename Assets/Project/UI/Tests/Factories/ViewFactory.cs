using UnityEngine;
using Zenject;

public class ViewFactory : MonoBehaviour
{
	[SerializeField] LicenseView licensePrefab;
	[SerializeField] CourseView coursePrefab;
	[SerializeField] AnimationView animationPrefabSmall;
	[SerializeField] AnimationView animationPrefabBig;
	[SerializeField] ObjectView objectPrefabSmall;
	[SerializeField] ObjectView objectPrefabBig;

	[Inject] DiContainer diContainer;
	[Inject] Database database;

	public enum AnimationType
	{
		Small,
		Big
	}

	public enum ObjectType
	{
		Small,
		Big
	}

	public CourseView CreateCourse(CourseData data, Transform parent)								=> Create(coursePrefab, data, parent) as CourseView;
	public LicenseView CreateLicense(Transform parent)												=> Create(licensePrefab, database.LicenseData, parent) as LicenseView;
	public AnimationView CreateAnimation(AnimationData data, Transform parent, AnimationType type)	=> Create(GetAnimationPrefab(type), data, parent) as AnimationView;
	public ObjectView CreateObject(ObjectData data, Transform parent, ObjectType type)				=> Create(GetObjectPrefab(type), data, parent) as ObjectView;

	AnimationView GetAnimationPrefab(AnimationType type)
	{
		switch (type)
		{
			case AnimationType.Small: return animationPrefabSmall;
			case AnimationType.Big: return animationPrefabBig;
			default: return null;
		}
	}

	ObjectView GetObjectPrefab(ObjectType type)
	{
		switch (type)
		{
			case ObjectType.Small: return objectPrefabSmall;
			case ObjectType.Big: return objectPrefabBig;
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
