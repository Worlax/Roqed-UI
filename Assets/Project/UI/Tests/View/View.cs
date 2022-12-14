using UnityEngine;

public class View : MonoBehaviour
{
	protected IData data;

	public void UpdateData(IData newData)
	{
		data = newData;
		Init();
	}

	protected virtual void Init() { }
}
