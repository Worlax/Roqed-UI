using UnityEngine;
using Zenject;

public abstract class Menu : MonoBehaviour
{
	[Inject] protected Database database;

	protected virtual void Awake()
	{
		if (!NeededOnScene()) { Destroy(gameObject); }
	}

	protected abstract bool NeededOnScene();
}