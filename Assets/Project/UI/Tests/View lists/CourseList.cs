using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CourseList : ViewListSynchronized<CourseData>
{
	[Inject] ViewFactory viewFactory;

	protected override List<IDataContainer<CourseData>> CreateAllItems(Transform parent)
	{
		List<IDataContainer<CourseData>> items = new List<IDataContainer<CourseData>>();

		foreach (CourseData data in FakeDataLoader.GetAllCourses())
		{
			items.Add(CreateItem(data, parent));
		}

		return items;
	}

	protected override IDataContainer<CourseData> CreateItem(Data data, Transform parent)
	{
		return viewFactory.CreateCourse(data as CourseData, parent);
	}

	protected override bool NeededOnScene()
	{
		return true;
	}
}
