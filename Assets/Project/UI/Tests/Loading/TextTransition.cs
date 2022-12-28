using UnityEngine;
using TMPro;

public class TextTransition : ItemTransitionDouble<string, TMP_Text>
{
	protected override string ItemHolder1Content
	{
		get => itemHolder1.text;
		set => itemHolder1.text = value;
	}

	protected override string ItemHolder2Content
	{
		get => itemHolder2.text;
		set => itemHolder2.text = value;
	}

	protected override string ActiveItemHolderContent
	{
		get => activeItemHolder.text;
		set => activeItemHolder.text = value;
	}

	protected override bool IsShowImageTimerOver()
	{
		return Time.realtimeSinceStartup - itemShowedAt >= ActiveItemHolderContent.Length * 0.1f * showItemSeconds;
	}
}
