using TMPro;
using UnityEngine;

public class ObjectView : View<ObjectData>
{
	[SerializeField] TMP_Text label;

	protected override void Init()
	{
		label.text = Data.Name;
	}
}
