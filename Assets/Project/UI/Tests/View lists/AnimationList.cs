<<<<<<< Updated upstream
using System;
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
	public static Action<AnimationView> OnNewAnimationStarted;

	void FillContent()
	{
		AnimationData[] animationData = ActiveCourse.Value.AnimtaionsData;
		if (animationData == null) { Destroy(gameObject); return; }

		foreach (AnimationData data in animationData)
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
			OnNewAnimationStarted?.Invoke(item);

			foreach (AnimationList list in activeLists)
			{
				if (list != this)
				{
					list.ActivateItem(item);
				}
			}
		}
=======
using System.Collections.Generic;
using UnityEngine;

public class AnimationList : ViewListSynchronized<AnimationData>
{
	protected override List<IDataContainer<AnimationData>> CreateAllItems(Transform parent)
	{
		throw new System.NotImplementedException();
	}

	protected override IDataContainer<AnimationData> CreateItem(Data data, Transform parent)
	{
		throw new System.NotImplementedException();
>>>>>>> Stashed changes
	}
}
