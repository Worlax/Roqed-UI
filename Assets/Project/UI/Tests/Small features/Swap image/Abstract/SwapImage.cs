using UnityEngine;
using UnityEngine.UI;

// Inspector preview is extended in "SwapImageEditor"
public class SwapImage : MonoBehaviour
{
	[SerializeField] [HideInInspector] bool useSprites = true;

	// Sprites
	[SerializeField] [HideInInspector] Image target;
	[SerializeField] [HideInInspector] Sprite spriteOn;
	[SerializeField] [HideInInspector] Sprite spriteOff;

	// Images
	[SerializeField] [HideInInspector] Image imageOn;
	[SerializeField] [HideInInspector] Image ImageOff;

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
