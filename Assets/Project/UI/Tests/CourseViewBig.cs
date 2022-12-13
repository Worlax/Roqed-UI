using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CourseViewBig : Window
{
	[SerializeField] Button closeButton;
	[SerializeField] Image preview;
	[SerializeField] new TMP_Text name;
	[SerializeField] TMP_Text group;
	[SerializeField] TMP_Text description;

	CourseData data;

	public override void Init<T>(T initData)
	{
		data = initData as CourseData;

		name.text = data.Name;
		group.text = data.Group;
		description.text = data.Description;
	}

	// Unity
	private void Start()
	{
		closeButton.onClick.AddListener(Close);
	}
}