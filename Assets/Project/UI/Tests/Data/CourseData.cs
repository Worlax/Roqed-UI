using System;
using System.Diagnostics;
using UnityEngine;

public class CourseData : Data
{
	public string Name;
	public string Group; // Format: "Base group/Subgroup name/Another subgroup/..."
	public string Description;
	public DateTime LastTimeOpened;
	public DateTime LastTimeUpdated;

	public ObjectData[] ObjectsData;
	public AnimationData[] AnimtaionsData;
	public PracticeData PracticeData;
	public TestData[] TestsData;

	public string[] GetAllGroups() => Group.Split("/");
	//public bool IsInGroup(string fullGroupName) => Group.StartsWith(fullGroupName);
	public bool IsInGroup(string fullGroupName)
	{
		bool startsWith = Group.StartsWith(fullGroupName);

		UnityEngine.Debug.Log($"Course '{Name}' with group: '{Group}' ({Group.Length} symbols) is in group: '{fullGroupName}' ({fullGroupName.Length} symbols) - {startsWith}");

		return startsWith;
	}
}
