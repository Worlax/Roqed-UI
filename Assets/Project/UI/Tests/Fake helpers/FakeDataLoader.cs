using UnityEngine;

public static class FakeDataLoader
{
	// Get data public
	public static CourseData[] GetAllCourses()
	{
		return FakeDataCreator.CreateMultipleCourses();
	}

	public static SettingsData GetSettings()
	{
		return new SettingsData()
		{
			Languages = new[] { "Русский", "English" },
			ActiveLanguage = "Русский",
			SavePath = @"C:\Roqed\Save",
			Email = "my.email@gmail.com",

			Interactive = true,
			BetaFeatures = false,
			OfflineMode = false,

			// Display
			Resolutions = new string[] { "1920 x 1080", "1600 x 900", "1360 x 768" },
			ActiveResolution = "1920 x 1080",
			GraphicQualitys = new string[] { "Высокие", "Низкие" },
			ActiveGraphicQuality = "Высокие",

			ShowFps = true,

			// Volume
			GeneralVolume = 0.7f,
			EffectsVolume = 0.1f,
			MusicVolume = 0.1f,
			VoiceVolume = 0.1f,

			EnableVoice = false
		};
	}

	public static LicenseData GetLicense()
	{
		return new LicenseData()
		{
			UserName = "CoolUser",
			Key = "ABCOOL",
			ActivationDate = new System.DateTime(2023, 1, 1),
			ValidityDays = 180
		};
	}

	public static BugReportData GetBugReport()
	{
		return new BugReportData() { Email = "hehe@gmail.com" };
	}
}
