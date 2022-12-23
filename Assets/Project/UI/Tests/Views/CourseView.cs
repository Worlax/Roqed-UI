using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

[RequireComponent(typeof(Button))]
public class CourseView : View<CourseData>
{
	[SerializeField] Image preview;
	[SerializeField] TMP_Text label;
	[Inject] WindowFactory windowFactory;

	protected override void Init()
	{
<<<<<<< Updated upstream
=======
		base.Init();

>>>>>>> Stashed changes
		label.text = Data.Name;
	}

	// Unity
	private void Start()
	{
		GetComponent<Button>().onClick.AddListener(OnClick);
	}

	// Events
	void OnClick()
	{
		windowFactory.CreateCourse(Data);
	}
}
