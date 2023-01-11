using System.Collections.Generic;

public class GroupData
{
	public string Name;
	public GroupData Parent;
	public IReadOnlyList<GroupData> Children => children;

	List<GroupData> children = new List<GroupData>();

	public GroupData FindChildren(string name) => children.Find(x => x.Name == name);

	public GroupData(string name)
	{
		Name = name;
	}	

	public string GetFullName()
	{
		string fullName = "";

		GroupData unwindParent = Parent;

		while (unwindParent != null)
		{
			fullName = unwindParent.Name + "/" + fullName;
			unwindParent = unwindParent.Parent;
		}

		return fullName + Name;
	}

	public void AddChildren(GroupData courseGroup)
	{
		if (!children.Contains(courseGroup))
		{
			children.Add(courseGroup);
		}
	}
}