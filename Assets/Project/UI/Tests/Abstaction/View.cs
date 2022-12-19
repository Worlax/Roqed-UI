using UnityEngine;

public abstract class View<T> : MonoBehaviour where T : Data
{
	protected T data;

	public void UpdateData(T newData)
	{
		data = newData;
		Init();
	}

	protected virtual void Init() { }
}