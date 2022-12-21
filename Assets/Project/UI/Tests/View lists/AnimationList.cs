using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(ToggleGroup))]
public class AnimationList : MonoBehaviour
{
	[SerializeField] Transform content;
	[SerializeField] ViewFactory.AnimationType itemsType;
	[Inject] ViewFactory viewFactory;

	static List<AnimationList> activeLists = new List<AnimationList>();

	void FillContent()
	{
		foreach (AnimationData data in FakeDataLoader.GetAllAnimations(null))
		{
			AnimationView item = viewFactory.CreateAnimation(data, content, itemsType);

			Toggle itemToggle = item.GetComponent<Toggle>();
			itemToggle.group = GetComponent<ToggleGroup>();
			itemToggle.onValueChanged.AddListener(x => ItemValueChanged(item, x));
		}
	}

	AnimationView FindItem(string name)
	{
		foreach (Transform item in content)
		{
			AnimationView animationView = item.GetComponent<AnimationView>();

			if (animationView != null && animationView.Data.Name == name)
			{
				return animationView;
			}
		}

		return null;
	}

	void ActivateItem(AnimationView item)
	{
		AnimationView animationView = FindItem(item.Data.Name);

		if (animationView != null)
		{
			Toggle toggle = animationView.GetComponent<Toggle>();

			if (toggle.isOn == false)
			{
				toggle.isOn = true;
			}
		}
	}

	// Unity
	private void Start()
	{
		activeLists.Add(this);
		FillContent();
	}

	private void OnDestroy()
	{
		activeLists.Remove(this);
	}

	// Events
	void ItemValueChanged(AnimationView item, bool value)
	{
		if (value)
		{
			foreach (AnimationList list in activeLists)
			{
				if (list != this)
				{
					list.ActivateItem(item);
				}
			}
		}
	}
}
