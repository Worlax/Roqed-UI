using TMPro;
using UnityEngine;

public class AnimationView : View<AnimationData>
{
	[SerializeField] TMP_Text label;

	protected override void Init()
	{
		label.text = data.Name;
	}
}
