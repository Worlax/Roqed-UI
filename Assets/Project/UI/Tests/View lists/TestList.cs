using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TestList : ViewList
{
	[Inject] ViewFactory viewFactory;

	protected override List<View<Data>> CreateAllItems(Transform parent)
	{
		print("??");
		List<View<Data>> items = new List<View<Data>>();

		foreach (CourseData data in FakeDataLoader.GetAllCourses())
		{
			print("1");
			items.Add(CreateItem(data, parent));
			print("2");
		}

		return items;
	}

	protected override View<Data> CreateItem(Data data, Transform parent)
	{
		print("!!");
		print((data as CourseData).Name);
		print("oww");
		CourseView courseView = viewFactory.CreateCourse(data as CourseData, parent);
		print("rr");
		View<Data> view = Convert.ChangeType(courseView, typeof(View<Data>)) as View<Data>;
		print("boink");

		//View<Data> view = courseView;

		if (courseView == null) { print("course"); }
		if (view == null) { print("view"); }

		print((Convert.ChangeType(view, typeof(CourseView)) as CourseView).Data.Name);

		return view;
	}
}