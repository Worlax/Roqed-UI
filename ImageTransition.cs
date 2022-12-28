using UnityEngine;
using UnityEngine.UI;

public class ImageTransition : ItemTransition<Sprite, Image>
{
	protected override Sprite itemHolder1Content
	{
		get => itemHolder1.sprite;
		set => itemHolder1.sprite = value;
	}

	protected override void Init()
	{
		itemHolder1.sprite = GetNextItemToShow();
		itemHolder2.sprite = GetNextItemToShow();

		activeItemHolder = itemHolder1;
		activeCanvasGroup = itemHolder1.GetComponent<CanvasGroup>();
	}

	protected override void SwapActiveElemetns()
	{
		activeItemHolder.transform.SetAsFirstSibling();
		activeItemHolder.sprite = GetNextItemToShow();
		activeCanvasGroup.alpha = 1;

		activeItemHolder = activeItemHolder == itemHolder1 ? itemHolder2 : itemHolder1;
		activeCanvasGroup = activeItemHolder.GetComponent<CanvasGroup>();
	}
}
