using System;
using System.Collections.Generic;
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
			Group = CreateRandomGroup(),
			Description = CreateRandomString(),
			LastTimeOpened = CreateRandomDate(),
			LastTimeUpdated = CreateRandomDate(),

			ObjectsData = CreateMultipleObjects(),
			AnimtaionsData = CreateMultipeAnimations(),
			PracticeData = CreatePracticeData(),
			TestsData = CreateMultipleTestData()
		};

		// Course content variations
		if (randomContent)
		{
			courseData.ObjectsData = FlipACoint() ? courseData.ObjectsData : null;
			courseData.AnimtaionsData = FlipACoint() ? courseData.AnimtaionsData : null;
			courseData.PracticeData = FlipACoint() ? courseData.PracticeData : null;
			courseData.TestsData = FlipACoint() ? courseData.TestsData : null;
		}

		return courseData;
	}

	static bool FlipACoint(int percentsToGetTrue = 50)
	{
		return UnityEngine.Random.Range(0, 100) <= percentsToGetTrue - 1;
	}

	static string[] groups0 = new string[] { "1. " + CreateRandomString(), "1. " + CreateRandomString(), "1. " + CreateRandomString() };
	static string[] groups1 = new string[] { "2. " + CreateRandomString(), "2. " + CreateRandomString(), "2. " + CreateRandomString() };
	static string[] groups2 = new string[] { "3. " + CreateRandomString(), "3. " + CreateRandomString(), "3. " + CreateRandomString() };
	static string[] groups3 = new string[] { "4. " + CreateRandomString(), "4. " + CreateRandomString(), "4. " + CreateRandomString() };

	static string CreateRandomGroup()
	{
		int GetRandomIndex() => UnityEngine.Random.Range(0, 3);

		string group = groups0[GetRandomIndex()];

		if (FlipACoint())
		{
			group += "/" + groups1[GetRandomIndex()];

			if (FlipACoint())
			{
				group += "/" + groups2[GetRandomIndex()];

				if (FlipACoint())
				{
					group += "/" + groups3[GetRandomIndex()];
				}
			}
		}

		return group;
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

	static DateTime CreateRandomDate()
	{
		return new DateTime(new System.Random().Next());
	}

	static string CreateRandomString()
	{
		string characters = "abcdefghijklmnopqrstuvwxyz";
		int stringLength = UnityEngine.Random.Range(8, 30);

		string result = "";

		for (int i = 0; i < stringLength; ++i)
		{
			result += characters[UnityEngine.Random.Range(0, characters.Length - 1)];
		}

		return result;
	}
}