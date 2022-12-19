using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GlobalButtons : MonoBehaviour
{
	[SerializeField] Button bugReport;
	[SerializeField] Button hide;
	[SerializeField] Button scale;
	[SerializeField] Button close;

	[Inject] WindowFactory windowFactory;

	// Unity
	private void Start()
	{
		close.onClick.AddListener(Close);
		hide.onClick.AddListener(Hide);
		scale.onClick.AddListener(Scale);
		bugReport.onClick.AddListener(BugReport);
	}

	// Events
	void Close()
	{
		Application.Quit();
	}

	void Hide()
	{

	}

	void Scale()
	{

	}

	void BugReport()
	{
		windowFactory.CreateBugReportWindow();
	}
}
