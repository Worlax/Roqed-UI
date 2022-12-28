using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ButtonMenu : Menu
{
	// Unity
	protected override void Awake()
	{
		base.Awake();
		GetComponent<Button>().onClick.AddListener(Clicked);
	}

	// Events
	protected abstract void Clicked();
}