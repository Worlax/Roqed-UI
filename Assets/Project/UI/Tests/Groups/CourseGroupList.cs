using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CourseGroupList : MonoBehaviour
{
	[SerializeField] CourseList courseList;
	[SerializeField] Transform dropdownsContent;
	[SerializeField] GroupDropdown baseDropdown;

	List<GroupData> rootGroups = new List<GroupData>();

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
		GroupData iteratedGroup = FindOrCreateRootGroup(rootName);

		for (int i = 1; i < groups.Length; ++i)
		{
			GroupData nextIteratedGroup = iteratedGroup.FindChildren(groups[i]);

			if (nextIteratedGroup == null)
			{
				nextIteratedGroup = new GroupData(groups[i]);
				nextIteratedGroup.Parent = iteratedGroup;
				iteratedGroup.AddChildren(nextIteratedGroup);
			}

			iteratedGroup = nextIteratedGroup;
		}
	}

	GroupData FindOrCreateRootGroup(string name)
	{
		GroupData group = rootGroups.Find(x => x.Name == name);

		if (group == null)
		{
			group = new GroupData(name);
			rootGroups.Add(group);
		}

		return group;
	}

	void UpdateActiveCourses(List<GroupData> activeGroups)
	{
		foreach (IDataContainer<CourseData> dataContainer in courseList.Items)
		{
			bool courseInGroup = IsCourseInAnyOfGroups(dataContainer.Data, activeGroups);
			dataContainer.GetGameObject().SetActive(courseInGroup);
		}
	}

	bool IsCourseInAnyOfGroups(CourseData data, List<GroupData> groups)
	{
		foreach (GroupData group in groups)
		{
			if (data.IsInGroup(group.GetFullName())) { return true; }
		}

		return false;
	}

	// Unity
	private void Start()
	{
		Init();
	}

	private void OnEnable()
	{
		GroupDropdown.OnNewGroupsSelectd += NewGroupsSelected;
	}

	private void OnDisable()
	{
		GroupDropdown.OnNewGroupsSelectd -= NewGroupsSelected;
	}

	// Events
	void NewGroupsSelected(List<GroupData> groups)
	{
		UpdateActiveCourses(groups);
	}
}
