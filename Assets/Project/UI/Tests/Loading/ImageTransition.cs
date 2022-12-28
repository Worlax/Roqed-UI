using UnityEngine;
using UnityEngine.UI;

public class ImageTransition : ItemTransitionDefault<Sprite, Image>
{
	protected override Sprite ItemHolder1Content
	{
		get => itemHolder1.sprite;
		set => itemHolder1.sprite = value;
	}

	protected override Sprite ItemHolder2Content
	{
		get => itemHolder2.sprite;
		set => itemHolder2.sprite = value;
	}

	protected override Sprite ActiveItemHolderContent
	{
		get => activeItemHolder.sprite;
		set => activeItemHolder.sprite = value;
	}
}
