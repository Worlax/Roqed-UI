using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class CourseViewSmall : MonoBehaviour
{
	[SerializeField] Image preview;
	[SerializeField] new TMP_Text name;

	CourseData data;

	public void Init(CourseData courseData)
	{
		data = courseData;
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
		Mediator.Instance.CreateCourseViewBigWindow(data);
	}
}
