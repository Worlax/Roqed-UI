using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

[RequireComponent(typeof(Button))]
public class CourseView : View<CourseData>
{
	[SerializeField] Image preview;
	[SerializeField] new TMP_Text name;
	[Inject] WindowFactory windowFactory;

	protected override void Init()
	{
		name.text = data.Name;
	}

	// Unity
	private void Start()
	{
		GetComponent<Button>().onClick.AddListener(OnClick);
	}

	// Events
	void OnClick()
	{
		windowFactory.CreateCourseWindow(data);
	}
}
