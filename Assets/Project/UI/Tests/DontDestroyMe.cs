using UnityEngine;

public class DontDestroyMe : MonoBehaviour
{
	// Unity
	private void Start()
	{
		DontDestroyOnLoad(gameObject);
	}
}
