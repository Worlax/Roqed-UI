using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CourseViewListSorting : MonoBehaviour
{
	[SerializeField] Transform content;

	[SerializeField] Toggle sortByName;
	[SerializeField] TMP_Text sortByNameLabel;
	[SerializeField] Toggle sortByOpenTime;
	[SerializeField] TMP_Text sortByOpenTimeLabel;
	[SerializeField] Toggle sortByUpdateTime;
	[SerializeField] TMP_Text sortByUpdateTimeLabel;

	TMP_Text activeLabel;

	int SortByName(CourseView one, CourseView two)			=> one.Data.Name.CompareTo(two.Data.Name);
	int SortByOpenTime(CourseView one, CourseView two)		=> one.Data.LastTimeOpened.CompareTo(two.Data.LastTimeOpened);
	int SortByUpdateTime(CourseView one, CourseView two)	=> one.Data.LastTimeUpdated.CompareTo(two.Data.LastTimeUpdated);

	List<CourseView> GetAllCourses()
	{
		List<CourseView> courses = new List<CourseView>();

		foreach (Transform transform in content)
		{
			courses.Add(transform.GetComponent<CourseView>());
		}

		return courses;
	}

	void SynchronizeListWithContent(List<CourseView> list)
	{
		for (int i = 0; i < list.Count; ++i)
		{
			list[i].transform.SetSiblingIndex(i);
		}
	}

	void ChangeActiveLabel(TMP_Text newActiveLabel)
	{
		if (activeLabel != null) activeLabel.fontStyle = FontStyles.Normal;

		activeLabel = newActiveLabel;
		activeLabel.fontStyle = FontStyles.Bold;
	}

	// Unity
	private void Start()
	{
		sortByName.onValueChanged.AddListener(
			value => OnSortToggleValueChanged(value, SortByName, sortByNameLabel));

		sortByOpenTime.onValueChanged.AddListener(
			value => OnSortToggleValueChanged(value, SortByOpenTime, sortByOpenTimeLabel));

		sortByUpdateTime.onValueChanged.AddListener(
			value => OnSortToggleValueChanged(value, SortByUpdateTime, sortByUpdateTimeLabel));

		// Startup sort
		OnSortToggleValueChanged(sortByOpenTime.isOn, SortByOpenTime, sortByOpenTimeLabel);
	}

	// Events
	void OnSortToggleValueChanged(bool value, Comparison<CourseView> sortingLogic, TMP_Text label)
	{
		List<CourseView> courses = GetAllCourses();
		courses.Sort(sortingLogic);
		if (value) courses.Reverse();

		SynchronizeListWithContent(courses);
		ChangeActiveLabel(label);
	}
}
