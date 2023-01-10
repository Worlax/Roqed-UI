using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CourseGroupList : MonoBehaviour
{
	[SerializeField] Transform courseContent;
	[SerializeField] Transform dropdownContent;
	[SerializeField] CourseGroupDropdown baseDropdown;

	List<CourseGroup> allGroups = new List<CourseGroup>();

	CourseGroup CreateGroup(string name) => new CourseGroup() { Name = name };
	List<CourseGroup> GetBaseGroups() => allGroups.Where(x => x.Parent == null).ToList();

	void Init()
	{
		foreach (CourseView courseView in GetAllCourses())
		{
			AddGroupsFromNames(courseView.Data.GetAllGroups());
		}

		baseDropdown.Init(GetBaseGroups());
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

	void AddGroupsFromNames(string[] groupHierarchy)
	{
		List<CourseGroup> parentHierarchy = new List<CourseGroup>();

		for (int i = 0; i < groupHierarchy.Count(); ++i)
		{
			CourseGroup group = FindGroup(parentHierarchy, groupHierarchy[i]);

			if (group == null)
			{
				group = CreateGroup(groupHierarchy[i]);
				allGroups.Add(group);
			}

			if (parentHierarchy.Count != 0)
			{
				group.Parent = parentHierarchy.Last();
				group.Parent.AddChildren(group);
			}

			parentHierarchy.Add(group);
		}

		string hierarchyString1= "";
		groupHierarchy.ToList().ForEach(x => hierarchyString1 += x + ", ");
		print($"Hierarchy array input: {hierarchyString1}");

		string hierarchyString = "";
		parentHierarchy.ForEach(x => hierarchyString += x.Name + ", ");
		print($"Hierarchy created: {hierarchyString}");
	}

	CourseGroup FindGroup(List<CourseGroup> parentHierarchy, string name)
	{
		string hierarchyString = "";
		parentHierarchy.ForEach(x => hierarchyString += x.Name + ", ");

		if (hierarchyString.Length > 0)
			hierarchyString = hierarchyString.Substring(0, hierarchyString.Length - 2);
		print($"Ttying to find: {name} with hieararchy: {hierarchyString}");

		foreach (CourseGroup group in allGroups)
		{
			if (group.Name == name && IsParentHierarchyMatch(parentHierarchy, group))
			{
				print("found");
				return group;
			}
		}

		print("fail");
		return null;
	}

	bool IsParentHierarchyMatch(List<CourseGroup> parentHierarchy, CourseGroup group)
	{
		parentHierarchy.Reverse();
		CourseGroup selectedParent = group.Parent;

		foreach (CourseGroup parent in parentHierarchy)
		{
			if (selectedParent == null || selectedParent.Name != parent.Name)
			{
				return false;
			}

			selectedParent = selectedParent.Parent;
		}

		return true;
	}

	bool IsCourseInAnyOfGroups(CourseView course, List<CourseGroup> groups)
	{
		foreach (CourseGroup group in groups)
		{
			if (course.Data.IsInGroup(group.GetFullName())) { return true; }
		}

		return false;
	}

	// Unity
	private void Start()
	{
		Init();

		CourseGroupDropdown.OnNewGroupsSelectd += NewGroupsSelected;
	}

	// Events
	void NewGroupsSelected(List<CourseGroup> groups)
	{
		groups.ForEach(x => print(x.GetFullName()));

		foreach (CourseView course in GetAllCourses())
		{
			bool courseInGroup = IsCourseInAnyOfGroups(course, groups);
			course.gameObject.SetActive(courseInGroup);
		}
	}
}
