using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(SwapImage), true)]
public class SwapImageEditor : Editor
{
	SerializedProperty useSprites;

	// Sprites
	new SerializedProperty target;
	SerializedProperty spriteOn;
	SerializedProperty spriteOff;

	// Images
	SerializedProperty imageOn;
	SerializedProperty ImageOff;

	// Unity
	private void OnEnable()
	{
		useSprites = serializedObject.FindProperty("useSprites");

		target = serializedObject.FindProperty("target");
		spriteOn = serializedObject.FindProperty("spriteOn");
		spriteOff = serializedObject.FindProperty("spriteOff");

		imageOn = serializedObject.FindProperty("imageOn");
		ImageOff = serializedObject.FindProperty("ImageOff");
	}

	public override void OnInspectorGUI()
	{
		EditorGUILayout.PropertyField(useSprites);

		if (useSprites.boolValue)
		{
			EditorGUILayout.PropertyField(target);
			EditorGUILayout.PropertyField(spriteOn);
			EditorGUILayout.PropertyField(spriteOff);
		}
		else
		{
			EditorGUILayout.PropertyField(imageOn);
			EditorGUILayout.PropertyField(ImageOff);
		}

		serializedObject.ApplyModifiedProperties();
	}
}