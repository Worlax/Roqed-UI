using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleContent : MonoBehaviour
{
	[SerializeField] List<Transform> content = new List<Transform>();

	// Unity
	private void Start()
	{
		Toggle toggle = GetComponent<Toggle>();
		toggle.onValueChanged.AddListener(ValueChanged);
		ValueChanged(toggle.isOn);
	}

	// Events
	void ValueChanged(bool value)
	{
		foreach (Transform item in content)
		{
			if (item != null)
			{
				item.gameObject.SetActive(value);
			}
		}
	}
}
