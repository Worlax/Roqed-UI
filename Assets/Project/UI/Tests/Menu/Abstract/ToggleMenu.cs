using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public abstract class ToggleMenu : MonoBehaviour
{
	// Unity
	protected virtual void Awake()
	{
		GetComponent<Toggle>().onValueChanged.AddListener(Toggled);
	}

	protected abstract void Toggled(bool value);
}