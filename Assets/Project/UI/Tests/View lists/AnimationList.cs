using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AnimationList : ViewListSynchronized<AnimationData>
{
	[SerializeField] ViewFactory.AnimationType animationType;
	[Inject] ViewFactory viewFactory;
	[Inject] Database database;

	protected override List<IDataContainer<AnimationData>> CreateAllItems(Transform parent)
	{
		List<IDataContainer<AnimationData>> items = new List<IDataContainer<AnimationData>>();

		foreach (AnimationData data in database.ActiveCourse.AnimtaionsData)
		{
			items.Add(CreateItem(data, parent));
		}

		return items;
	}

	protected override IDataContainer<AnimationData> CreateItem(Data data, Transform parent)
	{
		return viewFactory.CreateAnimation(data as AnimationData, parent, animationType);
	}
}
