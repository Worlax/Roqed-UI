using TMPro;
using UnityEngine;

public class AnimationLabel : MonoBehaviour
{
	[SerializeField] AnimationList animationList;
	[SerializeField] TMP_Text label;

	// Unity
	private void Start()
	{
		if (animationList.Doomed) { Destroy(gameObject); return; }

		NewAnimationStarted(animationList.GetActiveItem());
	}

	private void OnEnable()
	{
		AnimationList.OnNewItemToggled += NewAnimationStarted;
	}

	private void OnDisable()
	{
		AnimationList.OnNewItemToggled -= NewAnimationStarted;
	}

	// Events
	void NewAnimationStarted(AnimationData data)
	{
		label.text = data.Name;
	}
}
