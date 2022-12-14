using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class SettingsButton : MonoBehaviour
{
	[Inject] ViewFactory viewFactory;

	// Unity
	private void Start()
	{
		GetComponent<Button>().onClick.AddListener(Click);
	}

	// Events
	private void Click()
	{
		viewFactory.CreateSettingsWindow(FakeLoader.GetSettingsData());
	}
}
