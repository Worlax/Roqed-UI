using System.Collections.Generic;

public class CourseGroup
{
	public string Name;
	public CourseGroup Parent;
	public IReadOnlyList<CourseGroup> Children => children;

	List<CourseGroup> children = new List<CourseGroup>();

	public string GetFullName()
	{
		string fullName = "";

		if (Parent != null)
		{
			fullName += Parent.Name + "/";
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