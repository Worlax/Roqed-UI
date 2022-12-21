using UnityEngine;
using Zenject;

public class CourseList : MonoBehaviour
{
	[SerializeField] Transform content;
	[Inject] ViewFactory viewFactory;

	void FillContent()
	{
		foreach (CourseData data in FakeDataLoader.GetCoursesData())
		{
			viewFactory.CreateCourse(data, content);
		}
	}

	// Unity
	private void Start()
	{
		FillContent();
	}
}