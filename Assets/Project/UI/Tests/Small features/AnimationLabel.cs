using TMPro;
using UnityEngine;

public class AnimationLabel : MonoBehaviour
{
	[SerializeField] AnimationList animationList;
	[SerializeField] TMP_Text label;

	// Unity
	private void Start()
	{
		AnimationList.OnNewItemToggled += NewAnimationStarted;
		NewAnimationStarted(animationList.GetActiveItem());
	}

	// Events
	void NewAnimationStarted(AnimationData data)
	{
		label.text = data.Name;
	}
}
