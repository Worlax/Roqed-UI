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
		print("data " + data == null);
		print("viewFactory " + viewFactory == null);
		print("data as ICourseData " + (data as ICourseData) == null);

		if (data == null) print("data");
		if (viewFactory == null) print("viewFactory");
		if ((data as ICourseData) == null) print("(data as ICourseData)");
		viewFactory.CreateCourseWindow(data as ICourseData);
	}
}
