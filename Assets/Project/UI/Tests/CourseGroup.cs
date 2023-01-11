using System.Collections.Generic;

public class CourseGroup
{
	public string Name;
	public CourseGroup Parent;
	public IReadOnlyList<CourseGroup> Children => children;

	List<CourseGroup> children = new List<CourseGroup>();

	public CourseGroup FindChildren(string name) => children.Find(x => x.Name == name);

	public CourseGroup(string name)
	{
		Name = name;
	}	

	public string GetFullName()
	{
		string fullName = "";

		CourseGroup unwindParent = Parent;

		while (unwindParent != null)
		{
			fullName = unwindParent.Name + "/" + fullName;
			unwindParent = unwindParent.Parent;
		}

		return fullName + Name;
	}

	public void AddChildren(CourseGroup courseGroup)
	{
		if (!children.Contains(courseGroup))
		{
			children.Add(courseGroup);
		}
	}
}