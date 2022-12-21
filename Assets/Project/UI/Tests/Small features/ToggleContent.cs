using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleContent : MonoBehaviour
{
	[SerializeField] Transform content;

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
		content.gameObject.SetActive(value);
	}
}
