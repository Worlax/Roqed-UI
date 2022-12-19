using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BugReportWindow : Window<BugReportData>
{
	[SerializeField] Image screenshot;
	[SerializeField] TMP_InputField email;
	[SerializeField] TMP_InputField description;

	[SerializeField] Button report;

	protected override void Init()
	{
		email.text = data.Email;
		description.text = data.Description;
	}

	// Unity
	private void Start()
	{
		report.onClick.AddListener(Report);
	}

	// Events
	void Report()
	{
		Close();
	}
}
