using UnityEngine;
using Zenject;

public class AnimationList : MonoBehaviour
{
	[SerializeField] Transform content;
	[SerializeField] ViewFactory.AnimationType itemsType;
	[Inject] ViewFactory viewFactory;

	void FillContent()
	{
		foreach (AnimationData data in FakeDataLoader.GetAllAnimations(null))
		{
			viewFactory.CreateAnimation(data, content, itemsType);
		}
	}

	// Unity
	private void Start()
	{
		FillContent();
	}
}
