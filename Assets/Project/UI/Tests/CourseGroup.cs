using System.Collections.Generic;

public class CourseGroup
{
	public string Name;
	public CourseGroup Parent;
	public List<CourseGroup> Children = new List<CourseGroup>();
}