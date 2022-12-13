using UnityEngine;
using UnityEngine.UI;

public class CourseList : MonoBehaviour
{
	[SerializeField] Transform content;
	[SerializeField] CourseViewSmall courseViewPrefab;

	void FillContent()
	{
		foreach (CourseData coures in FakeLoader.LoadCourses())
		{
			CourseViewSmall item = Instantiate(courseViewPrefab, content);
			item.Init(coures);
		}
	}

	// Unity
	private void Start()
	{
		FillContent();
	}
}
