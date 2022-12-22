using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleImage : SwapImage
{
	override protected void SubscribeSetEvents()
	{
		Toggle toggle = GetComponent<Toggle>();
		toggle.onValueChanged.AddListener(SetImageState);
	}

	protected override bool GetCurrentValue()
	{
		return GetComponent<Toggle>().isOn;
	}
}
