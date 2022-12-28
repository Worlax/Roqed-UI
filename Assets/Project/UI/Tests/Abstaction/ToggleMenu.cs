using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public abstract class ToggleMenu : Menu
{
	// Unity
	protected override void Awake()
	{
		base.Awake();
		GetComponent<Toggle>().onValueChanged.AddListener(Toggled);
	}

	// Events
	protected abstract void Toggled(bool value);
}