using TMPro;
using UnityEngine;

public class AnimationLabel : MonoBehaviour
{
	[SerializeField] TMP_Text label;

	// Unity
	private void Start()
	{
		print("TODO");
		//AnimationList.OnNewAnimationStarted += NewAnimationStarted;
	}

	// Events
	void NewAnimationStarted(AnimationView animationView)
	{
		label.text = animationView.Data.Name;
	}
}
