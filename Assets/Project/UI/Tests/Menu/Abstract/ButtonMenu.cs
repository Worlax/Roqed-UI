using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ButtonMenu : MonoBehaviour
{
	// Unity
	private void Awake()
	{
		GetComponent<Button>().onClick.AddListener(Clicked);
	}

	// Events
	protected abstract void Clicked();
}