using UnityEngine;
using UnityEngine.UI;

// gameObject = off -> toggle = off
// gameObject = on -> toggle = last state;
[RequireComponent(typeof(Toggle))]
public class HoldToggle : MonoBehaviour
{
	bool onHold;
	Toggle toggle;

	// Unity
	private void Awake()
	{
		toggle = GetComponent<Toggle>();
	}

	private void OnDisable()
	{
		onHold = toggle.isOn;
		toggle.isOn = false;
	}

	private void OnEnable()
	{
		toggle.isOn = onHold;
	}
}