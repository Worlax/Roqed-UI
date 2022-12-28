using UnityEngine;

public abstract class ItemTransitionDouble<T1, T2> : ItemTransition<T1, T2> where T2 : MonoBehaviour
{
	protected override void Animate()
	{
		if (!IsShowImageTimerOver()) { return; }

		if (activeCanvasGroup == inactiveCanvasGroup) { print("!!!"); }

		if (activeCanvasGroup.alpha > 0)
		{
			//print("1");
			activeCanvasGroup.alpha -= transitionSpeed * Time.deltaTime;
		}
		else if (inactiveCanvasGroup.alpha < 1)
		{
			//print("2");
			inactiveCanvasGroup.alpha += transitionSpeed * Time.deltaTime;
		}
		else
		{
			//print("3");
			SwapActiveElemetns();
			SetShowItemTimer();
			inactiveCanvasGroup.alpha = 0f;
		}
	}
}