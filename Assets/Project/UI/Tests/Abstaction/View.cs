using UnityEngine;

public abstract class View<T> : MonoBehaviour where T : Data
{
	public T Data { get; private set; }

	public void UpdateData(T newData)
	{
		Data = newData;
		Init();
	}

	protected virtual void Init() { }
}