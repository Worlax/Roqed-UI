using System;
using UnityEngine;

public interface IDataContainer<T> where T : Data
{
	public T Data { get; }

	public void UpdateData(T newData);
	public GameObject GetGameObject();
}

public abstract class View<T> : MonoBehaviour, IDataContainer<T> where T : Data
{
	public T Data { get; private set; }

	public void UpdateData(T newData)
	{
		Data = newData;
		Init();
	}

	public GameObject GetGameObject()
	{
		return gameObject;
	}

	protected virtual void Init()
	{
		if (Data == null) throw new Exception("Data is not set.");
	}
}