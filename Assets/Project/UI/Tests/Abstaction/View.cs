<<<<<<< Updated upstream
using System;
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
using UnityEngine;

public interface IView<Data>
{

}

public abstract class View<T> : MonoBehaviour where T : Data
=======
using System;
using UnityEngine;

public interface IDataContainer<T> where T : Data
{
	public T Data { get; }

	public void UpdateData(T newData);
	GameObject GetGameObject();
}

public abstract class View<T> : MonoBehaviour, IDataContainer<T> where T : Data
>>>>>>> Stashed changes
{
	public T Data { get; private set; }

	public void UpdateData(T newData)
	{
		Data = newData;
		Init();
	}

<<<<<<< Updated upstream
	protected virtual void Init() { }
=======
	public GameObject GetGameObject()
	{
		return gameObject;
	}

	protected virtual void Init()
	{
		if (Data == null) throw new Exception("Data is not set.");
	}
>>>>>>> Stashed changes
}