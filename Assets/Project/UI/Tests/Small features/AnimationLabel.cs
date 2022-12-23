using TMPro;
using UnityEngine;

public class AnimationLabel : MonoBehaviour
{
	[SerializeField] TMP_Text label;

	// Unity
	private void Start()
	{
<<<<<<< Updated upstream
		AnimationList.OnNewAnimationStarted += NewAnimationStarted;
=======
		print("TODO");
		//AnimationList.OnNewAnimationStarted += NewAnimationStarted;
>>>>>>> Stashed changes
	}

	// Events
	void NewAnimationStarted(AnimationView animationView)
	{
		label.text = animationView.Data.Name;
	}
}
