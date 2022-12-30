using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CourseSearch : MonoBehaviour
{
	[SerializeField] Transform content;
	[SerializeField] TMP_InputField searchField;

	List<CourseView> GetAllCourses()
	{
		List<CourseView> courses = new List<CourseView>();

		foreach (Transform transform in content)
		{
			courses.Add(transform.GetComponent<CourseView>());
		}

		return courses;
	}

	// Unity
	private void Start()
	{
		searchField.onValueChanged.AddListener(SearchFieldValueChanged);
	}

	// Events
	void SearchFieldValueChanged(string newValue)
	{
		List<CourseView> courses = GetAllCourses();

		foreach (CourseView course in courses)
		{
			bool containsValue = course.Data.Name.Contains(newValue);
			course.gameObject.SetActive(containsValue);
		}
	}
}
