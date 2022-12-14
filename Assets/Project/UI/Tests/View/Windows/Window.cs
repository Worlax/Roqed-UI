using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : View
{
	[SerializeField] Button closeButton;

	public static Action<Window> OnCreated;
	public static Action<Window> OnClosed;

	static List<Window> activeWindows;
	public static IEnumerable<Window> ActiveWindows => activeWindows;

	public void Close()
	{
		activeWindows.Remove(this);
		OnClosed?.Invoke(this);
		Destroy(gameObject);
	}

	// Unity
	public virtual void Start()
	{
		activeWindows.Add(this);
		OnCreated?.Invoke(this);

		closeButton?.onClick.AddListener(Close);
	}
}
