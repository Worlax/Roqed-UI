using UnityEngine;

public static class FakeLoader
{
	public static SettingsData LoadSettings()
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

	public static CourseData[] LoadCourses()
	{
		return new CourseData[7]
		{
			CreateRandomCourse(),
			CreateRandomCourse(),
			CreateRandomCourse(),
			CreateRandomCourse(),
			CreateRandomCourse(),
			CreateRandomCourse(),
			CreateRandomCourse()
		};
	}

	static CourseData CreateRandomCourse()
	{
		return new CourseData()
		{
			Name = GetRandomString(),
			Group = GetRandomString(),
			Description = GetRandomString()
		};
	}

	static string GetRandomString()
	{
		string characters = "abcdefghijklmnopqrstuvwxyz";
		int stringLength = Random.Range(8, 30);

		string result = "";

		for (int i = 0; i < stringLength; ++i)
		{
			result += characters[Random.Range(0, characters.Length - 1)];
		}

		return result;
	}
}
