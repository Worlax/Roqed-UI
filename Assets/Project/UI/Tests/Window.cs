using System;
using UnityEngine;

public abstract class Window : MonoBehaviour
{
	public Action OnClosed;

	public abstract void Init<T>(T initData);

	private void OnDestroy()
	{
		OnClosed?.Invoke();
	}

	protected virtual void Close()
	{
		Destroy(gameObject);
	}
}
