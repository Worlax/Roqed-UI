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
		base.OnInspectorGUI();

		useSprites.boolValue = EditorGUILayout.Toggle("Use Images", useSprites.boolValue);
		GUI.enabled = useSprites.boolValue;
		EditorGUILayout.PropertyField(target);
		EditorGUILayout.PropertyField(spriteOn);
		EditorGUILayout.PropertyField(spriteOff);
		GUI.enabled = true;
		EditorGUILayout.Space();

		useSprites.boolValue = !EditorGUILayout.Toggle("Use Sprites", !useSprites.boolValue);
		GUI.enabled = !useSprites.boolValue;
		EditorGUILayout.PropertyField(imageOn);
		EditorGUILayout.PropertyField(ImageOff);
		GUI.enabled = true;

		serializedObject.ApplyModifiedProperties();
	}
}