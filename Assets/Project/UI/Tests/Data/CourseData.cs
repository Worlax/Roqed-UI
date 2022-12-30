using System;

public class CourseData : Data
{
	public string Name;
	public string Group;
	public string Description;
	public DateTime LastTimeOpened;
	public DateTime LastTimeUpdated;

	public ObjectData[] ObjectsData;
	public AnimationData[] AnimtaionsData;
	public PracticeData PracticeData;
	public TestData[] TestsData;
}
