using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class CourseGroupList : MonoBehaviour
{
	[SerializeField] Transform courseContent;
	[SerializeField] Transform dropdownContent;
	[SerializeField] TMP_Dropdown baseDropdown;
	[SerializeField] TMP_Dropdown dropDownPrefab;

	List<CourseGroup> allGroups = new List<CourseGroup>();
	static char GROUP_SPLITTER = '/';

	CourseGroup FindGroup(string name) => allGroups.Find(x => x.Name == name);
	CourseGroup CreateGroup(string name) => new CourseGroup() { Name = name };
	List<CourseGroup> GetBaseGroups() => allGroups.Where(x => x.Parent == null).ToList();

	void Init()
	{
		foreach (CourseView courseView in GetAllCourses())
		{
			AddGroupsFromNames(courseView.Data.Group);
		}

		FillDropdown(baseDropdown, GetBaseGroups());
	}

	List<CourseView> GetAllCourses()
	{
		List<CourseView> courses = new List<CourseView>();

		foreach (Transform transform in courseContent)
		{
			courses.Add(transform.GetComponent<CourseView>());
		}

		return courses;
	}

	void AddGroupsFromNames(string groupNames)
	{
		List<CourseGroup> groupsUsedInScope = new List<CourseGroup>();
		string[] splitedGroupNames = groupNames.Split(GROUP_SPLITTER);

		foreach (string groupName in splitedGroupNames)
		{
			CourseGroup group = FindGroup(groupName);

			if (group == null)
			{
				group = CreateGroup(groupName);
				allGroups.Add(group);
			}

			if (groupsUsedInScope.Count != 0)
			{
				group.Parent = groupsUsedInScope.Last();
				group.Parent.Children.Add(group);
			}

			groupsUsedInScope.Add(group);
		}
	}

	void FillDropdown(TMP_Dropdown dropdown, List<CourseGroup> groups)
	{
		dropdown.options.Clear();

		foreach (CourseGroup group in groups)
		{
			dropdown.options.Add(new TMP_Dropdown.OptionData(group.Name));
		}
	}

	// Unity
	private void Start()
	{
		Init();
		baseDropdown.onValueChanged.AddListener(BaseDropdownValueChanged);
	}

	// Events
	void BaseDropdownValueChanged(int value)
	{
		CourseGroup selectedGroup = FindGroup(baseDropdown.options[value].text);
		TMP_Dropdown newDropdown = Instantiate(dropDownPrefab, dropdownContent);

		FillDropdown(newDropdown, selectedGroup.Children);
		newDropdown.onValueChanged.AddListener(BaseDropdownValueChanged);
	}
}
