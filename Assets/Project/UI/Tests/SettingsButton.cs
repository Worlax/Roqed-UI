using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SettingsButton : MonoBehaviour
{
	// Unity
	private void Start()
	{
		GetComponent<Button>().onClick.AddListener(Click);
	}

	// Events
	private void Click()
	{
		Mediator.Instance.CreateSettingsWindow(FakeLoader.LoadSettings());
	}
}
