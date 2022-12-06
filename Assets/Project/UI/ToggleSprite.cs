using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleSprite : MonoBehaviour
{
	[SerializeField] Image image;
	[SerializeField] Sprite spriteOn;
	[SerializeField] Sprite spriteOff;

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
		image.sprite = value ? spriteOn : spriteOff;
	}
}
