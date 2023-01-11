using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CourseGroupList : MonoBehaviour
{
	[SerializeField] CourseList courseList;
	[SerializeField] Transform dropdownsContent;
	[SerializeField] CourseGroupDropdown baseDropdown;

	List<CourseGroup> rootGroups = new List<CourseGroup>();

	void Init()
	{
		CreateGroups();
		baseDropdown.Init(rootGroups);
	}

	void CreateGroups()
	{
		foreach (CourseData data in courseList.Items.Select(x => x.Data))
		{
			CreateGroups(data.GetAllGroups());
		}
	}

	void CreateGroups(string[] groups)
	{
		string rootName = groups[0];
		CourseGroup iteratedGroup = FindOrCreateRootGroup(rootName);

		for (int i = 1; i < groups.Length; ++i)
		{
			CourseGroup nextIteratedGroup = iteratedGroup.FindChildren(groups[i]);

			if (nextIteratedGroup == null)
			{
				nextIteratedGroup = new CourseGroup(groups[i]);
				nextIteratedGroup.Parent = iteratedGroup;
				iteratedGroup.AddChildren(nextIteratedGroup);
			}

			iteratedGroup = nextIteratedGroup;
		}
	}

	CourseGroup FindOrCreateRootGroup(string name)
	{
		CourseGroup group = rootGroups.Find(x => x.Name == name);

		if (group == null)
		{
			group = new CourseGroup(name);
			rootGroups.Add(group);
		}

		return group;
	}

	void UpdateActiveCourses(List<CourseGroup> activeGroups)
	{
		foreach (IDataContainer<CourseData> dataContainer in courseList.Items)
		{
			bool courseInGroup = IsCourseInAnyOfGroups(dataContainer.Data, activeGroups);
			dataContainer.GetGameObject().SetActive(courseInGroup);
		}
	}

	bool IsCourseInAnyOfGroups(CourseData data, List<CourseGroup> groups)
	{
		string activeGroups = string.Join(", ", groups.Select(x => x.GetFullName()));
		print($"New active groups: {activeGroups}");

		foreach (CourseGroup group in groups)
		{
			if (data.IsInGroup(group.GetFullName())) { return true; }
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
		UpdateActiveCourses(groups);
	}
}
