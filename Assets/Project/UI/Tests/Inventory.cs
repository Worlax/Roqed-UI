using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField] Transform content;

	KeyCode openKey = KeyCode.Q;

	void ToggleVisibilityListener()
	{
		if (Input.GetKeyDown(openKey))
		{
			content.gameObject.SetActive(!content.gameObject.activeSelf);
		}
	}

	// Unity
	private void Update()
	{
		ToggleVisibilityListener();
	}
}
