using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleSprite : MonoBehaviour
{
	[SerializeField] Image target;
	[SerializeField] Sprite on;
	[SerializeField] Sprite off;

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
		target.sprite = value ? on : off;
	}
}
