using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderImage : SwapImage
{
	protected override void SubscribeSetEvents()
	{
		Slider slider = GetComponent<Slider>();
		slider.onValueChanged.AddListener(SliderValueChanged);
	}

	protected override bool GetCurrentValue()
	{
		return GetComponent<Slider>().value != 0;
	}

	void SliderValueChanged(float value)
	{
		SetImageState(value != 0);
	}
}
