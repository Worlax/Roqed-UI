using Zenject;

public class DataBase
{
	[Inject] public SettingsData settingsData;
	[Inject] public LicenseData licenseData;
	[Inject] public BugReportData BugReportData;
}
