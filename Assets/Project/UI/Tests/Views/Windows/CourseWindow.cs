using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CourseWindow : Window<CourseData>
{
	[SerializeField] Image preview;
	[SerializeField] new TMP_Text name;
	[SerializeField] TMP_Text group;
	[SerializeField] TMP_Text description;

	protected override void Init()
	{
		name.text = data.Name;
		group.text = data.Group;
		description.text = data.Description;
	}
}