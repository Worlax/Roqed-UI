using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleContent : MonoBehaviour
{
	[SerializeField] Transform content;

	// Unity
	private void Start()
	{
		GetComponent<Toggle>().onValueChanged.AddListener(ValueChanged);
	}

	// Events
	void ValueChanged(bool value)
	{
		content.gameObject.SetActive(value);
	}
}
