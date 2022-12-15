using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

[RequireComponent(typeof(Button))]
public class CourseView : View
{
	[SerializeField] Image preview;
	[SerializeField] new TMP_Text name;
	[Inject] ViewFactory viewFactory;

	protected override void Init()
	{
		ICourseData courseData = data as ICourseData;

		name.text = courseData.Name;
	}

	// Unity
	private void Start()
	{
		GetComponent<Button>().onClick.AddListener(OnClick);
	}

	// Events
	void OnClick()
	{
		viewFactory.CreateCourseWindow(data as ICourseData);
	}
}
