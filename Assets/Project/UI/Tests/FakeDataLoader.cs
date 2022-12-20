using UnityEngine;

public static class FakeDataLoader
{
	public static SettingsData GetSettingsData()
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

	static AnimationData[] animationData;

	public static AnimationData[] GetAllAnimations(CourseData courseData)
	{
		if (animationData == null)
		{
			animationData = new AnimationData[7]
			{
				CreateRundomAnimationData(),
				CreateRundomAnimationData(),
				CreateRundomAnimationData(),
				CreateRundomAnimationData(),
				CreateRundomAnimationData(),
				CreateRundomAnimationData(),
				CreateRundomAnimationData()
			};
		}

		return animationData;
	}

	static AnimationData CreateRundomAnimationData()
	{
		return new AnimationData()
		{
			Name = GetRandomString()
		};
	}

	public static LicenseData GetLicenseData()
	{
		return new LicenseData()
		{
			UserName = "CoolUser",
			Key = "ABCOOL",
			ActivationDate = new System.DateTime(2023, 1, 1),
			ValidityDays = 180
		};
	}

	public static BugReportData GetBugReportData()
	{
		return new BugReportData() { Email = "hehe@gmail.com" };
	}

	static CourseData[] courseData;

	public static CourseData[] GetCoursesData()
	{
		if (courseData == null)
		{
			courseData = new CourseData[7]
			{
				CreateRandomCourseData(),
				CreateRandomCourseData(),
				CreateRandomCourseData(),
				CreateRandomCourseData(),
				CreateRandomCourseData(),
				CreateRandomCourseData(),
				CreateRandomCourseData()
			};
		}

		return courseData;
	}

	static CourseData CreateRandomCourseData()
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
