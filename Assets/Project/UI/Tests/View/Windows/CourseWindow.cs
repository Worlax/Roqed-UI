using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CourseWindow : Window
{
	[SerializeField] Image preview;
	[SerializeField] new TMP_Text name;
	[SerializeField] TMP_Text group;
	[SerializeField] TMP_Text description;

	protected override void Init()
	{
		ICourseData courseData = data as ICourseData;

		name.text = courseData.Name;
		group.text = courseData.Group;
		description.text = courseData.Description;
	}
}