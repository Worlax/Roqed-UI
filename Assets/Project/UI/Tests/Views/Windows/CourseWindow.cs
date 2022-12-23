using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class CourseWindow : Window<CourseData>
{
	[SerializeField] Image preview;
	[SerializeField] TMP_Text label;
	[SerializeField] TMP_Text group;
	[SerializeField] TMP_Text description;
	[SerializeField] Button play;

	[Inject] SceneLoader courseLoader;

	protected override void Init()
	{
<<<<<<< Updated upstream
=======
		base.Init();

>>>>>>> Stashed changes
		label.text = Data.Name;
		group.text = Data.Group;
		description.text = Data.Description;
	}

	// Unity
	private void Start()
	{
		play.onClick.AddListener(Play);
	}

	// Events
	void Play()
	{
		courseLoader.LoadCourse(Data);
		Close();
	}
}