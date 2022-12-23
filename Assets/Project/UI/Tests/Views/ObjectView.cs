using TMPro;
using UnityEngine;

public class ObjectView : View<ObjectData>
{
	[SerializeField] TMP_Text label;

	protected override void Init()
	{
<<<<<<< Updated upstream
=======
		base.Init();

>>>>>>> Stashed changes
		label.text = Data.Name;
	}
}
