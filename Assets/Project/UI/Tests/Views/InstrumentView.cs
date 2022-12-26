using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class InstrumentView : View<InstrumentData>
{
	[SerializeField] TMP_Text label;

	public Action OnClicked;

	protected override void Init()
	{
		base.Init();

		label.name = Data.Name;
	}

	// Unity
	private void Start()
	{
		GetComponent<Button>().onClick.AddListener(OnClick);
	}

	// Events
	void OnClick()
	{
		OnClicked?.Invoke();
	}
}
