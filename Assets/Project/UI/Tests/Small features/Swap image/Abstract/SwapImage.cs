using UnityEngine;
using UnityEngine.UI;

// Inspector preview is extended in "SwapImageEditor"
public class SwapImage : MonoBehaviour
{
	[SerializeField] bool useSprites = true;

	// Sprites
	[SerializeField] Image target;
	[SerializeField] Sprite spriteOn;
	[SerializeField] Sprite spriteOff;

	// Images
	[SerializeField] Image imageOn;
	[SerializeField] Image ImageOff;

	protected virtual void SubscribeSetEvents() { }
	protected virtual bool GetCurrentValue() { return true; }

	// Unity
	protected virtual void Start()
	{
		SubscribeSetEvents();
		SetImageState(GetCurrentValue());
	}

	// Events
	protected void SetImageState(bool value)
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
