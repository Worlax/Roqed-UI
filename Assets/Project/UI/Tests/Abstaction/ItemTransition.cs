using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemTransition<T1, T2> : MonoBehaviour where T2 : MonoBehaviour
{
	[SerializeField] protected T2 itemHolder1;
	[SerializeField] protected T2 itemHolder2;
	[SerializeField][Min(0)] protected float showItemSeconds = 1;
	[SerializeField][Range(0.1f, 10)] protected float transitionSpeed = 1;
	[SerializeField] protected T1[] items;

	protected CanvasGroup activeCanvasGroup;
	protected CanvasGroup inactiveCanvasGroup;
	protected float itemShowedAt;

	protected Stack<T1> itemsToShow = new Stack<T1>();
	protected T2 activeItemHolder;

	protected abstract T1 ItemHolder1Content { get; set; }
	protected abstract T1 ItemHolder2Content { get; set; }
	protected abstract T1 ActiveItemHolderContent { get; set; }

	protected virtual void SetShowItemTimer() => itemShowedAt = Time.realtimeSinceStartup;
	protected virtual bool IsShowImageTimerOver() => (Time.realtimeSinceStartup - itemShowedAt) >= showItemSeconds;

	protected virtual void Init()
	{
		ItemHolder1Content = GetNextItemToShow();
		ItemHolder2Content = GetNextItemToShow();

		activeItemHolder = itemHolder1;
		activeCanvasGroup = itemHolder1.GetComponent<CanvasGroup>();
		inactiveCanvasGroup = itemHolder2.GetComponent<CanvasGroup>();
	}

	protected virtual void SwapActiveElemetns()
	{
		activeItemHolder.transform.SetAsFirstSibling();
		ActiveItemHolderContent = GetNextItemToShow();
		activeCanvasGroup.alpha = 1;

		activeItemHolder = activeItemHolder == itemHolder1 ? itemHolder2 : itemHolder1;
		activeCanvasGroup = activeItemHolder.GetComponent<CanvasGroup>();
		inactiveCanvasGroup = activeItemHolder == itemHolder1 ? itemHolder2.GetComponent<CanvasGroup>() : itemHolder1.GetComponent<CanvasGroup>();
	}

	protected abstract void Animate();

	protected virtual T1 GetNextItemToShow()
	{
		if (itemsToShow.Count == 0) { FillItemsToShow(); }
		return itemsToShow.Pop();
	}

	protected virtual void FillItemsToShow()
	{
		System.Random random = new System.Random();
		itemsToShow = new Stack<T1>(items.OrderBy(x => random.Next()));
	}

	// Unity
	protected virtual void Awake()
	{
		Init();
	}

	protected virtual void Update()
	{
		Animate();
	}
}