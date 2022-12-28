using UnityEngine;

public static class FakeDataCreator
{
	public static CourseData[] CreateMultipleCourses()
	{
		return new CourseData[7]
		{
			CreateRandomCourse(false),
			CreateRandomCourse(),
			CreateRandomCourse(),
			CreateRandomCourse(),
			CreateRandomCourse(),
			CreateRandomCourse(),
			CreateRandomCourse()
		};
	}

	static CourseData CreateRandomCourse(bool randomContent = true)
	{
		CourseData courseData = new CourseData()
		{
			Name = CreateRandomString(),
			Group = CreateRandomString(),
			Description = CreateRandomString(),

			ObjectsData = CreateMultipleObjects(),
			AnimtaionsData = CreateMultipeAnimations(),
			PracticeData = CreatePracticeData(),
			TestsData = CreateMultipleTestData()
		};

		// Course content variations
		if (randomContent)
		{
			courseData.ObjectsData = Random.Range(0, 2) == 0 ? courseData.ObjectsData : null;
			courseData.AnimtaionsData = Random.Range(0, 2) == 0 ? courseData.AnimtaionsData : null;
			courseData.PracticeData = Random.Range(0, 2) == 0 ? courseData.PracticeData : null;
			courseData.TestsData = Random.Range(0, 2) == 0 ? courseData.TestsData : null;
		}

		return courseData;
	}

	static TestData[] CreateMultipleTestData()
	{
		return new TestData[7]
		{
			CreateTestData(),
			CreateTestData(),
			CreateTestData(),
			CreateTestData(),
			CreateTestData(),
			CreateTestData(),
			CreateTestData()
		};
	}

	static TestData CreateTestData()
	{
		return new TestData()
		{

		};
	}

	static PracticeData CreatePracticeData()
	{
		return new PracticeData()
		{

		};
	}

	static ObjectData[] CreateMultipleObjects()
	{
		return new ObjectData[7]
		{
			CreateRandomObject(),
			CreateRandomObject(),
			CreateRandomObject(),
			CreateRandomObject(),
			CreateRandomObject(),
			CreateRandomObject(),
			CreateRandomObject()
		};
	}

	static AnimationData[] CreateMultipeAnimations()
	{
		return new AnimationData[7]
		{
			CreateRandomAnimation(),
			CreateRandomAnimation(),
			CreateRandomAnimation(),
			CreateRandomAnimation(),
			CreateRandomAnimation(),
			CreateRandomAnimation(),
			CreateRandomAnimation()
		};
	}

	static ObjectData CreateRandomObject()
	{
		return new ObjectData()
		{
			Name = CreateRandomString()
		};
	}

	static AnimationData CreateRandomAnimation()
	{
		return new AnimationData()
		{
			Name = CreateRandomString()
		};
	}

	static string CreateRandomString()
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