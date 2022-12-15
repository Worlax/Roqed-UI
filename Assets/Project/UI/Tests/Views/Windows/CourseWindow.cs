using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class CourseWindow : Window<CourseData>
{
	[SerializeField] Image preview;
	[SerializeField] new TMP_Text name;
	[SerializeField] TMP_Text group;
	[SerializeField] TMP_Text description;
	[SerializeField] Button play;

	[Inject] CourseLoader courseLoader;

	protected override void Init()
	{
		name.text = data.Name;
		group.text = data.Group;
		description.text = data.Description;
	}

	// Unity
	private void Start()
	{
		play.onClick.AddListener(Play);
	}

	// Events
	void Play()
	{
		courseLoader.Load(data);
	}
}