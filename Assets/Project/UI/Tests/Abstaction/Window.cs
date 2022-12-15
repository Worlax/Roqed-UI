using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window<T> : View<T> where T : Data
{
	[SerializeField] Button closeButton;

	public Action<Window<T>> OnClose;

	public void Close()
	{
		OnClose?.Invoke(this);
		Destroy(gameObject);
	}

	protected virtual void Awake()
	{
		closeButton?.onClick.AddListener(Close);
	}
}
