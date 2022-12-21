using UnityEngine;
using UnityEngine.UI;

// Inspector preview is extended in "ToggleImageEditor"
[RequireComponent(typeof(Toggle))]
public class ToggleImage : MonoBehaviour
{
	[SerializeField] bool useSprites = true;

	// Sprites
	[SerializeField] Image target;
	[SerializeField] Sprite spriteOn;
	[SerializeField] Sprite spriteOff;

	// Images
	[SerializeField] Image imageOn;
	[SerializeField] Image ImageOff;

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
		if (useSprites)
		{
			target.sprite = value ? spriteOn : spriteOff;
		}
		else
		{
			imageOn.gameObject.SetActive(value);
			ImageOff?.gameObject.SetActive(!value);
		}
	}
}
