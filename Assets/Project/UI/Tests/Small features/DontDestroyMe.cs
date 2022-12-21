using UnityEngine;

public class DontDestroyMe : MonoBehaviour
{
	// Unity
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
}
