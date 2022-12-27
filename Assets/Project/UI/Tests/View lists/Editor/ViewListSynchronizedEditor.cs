using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ViewListSynchronized<>), true)]
public class ViewListSynchronizedEditor : Editor
{
	SerializedProperty uniqueSynchronization;
	SerializedProperty uniqueSynchronizationId;

	private void OnEnable()
	{
		uniqueSynchronization = serializedObject.FindProperty("uniqueSynchronization");
		uniqueSynchronizationId = serializedObject.FindProperty("uniqueSynchronizationId");
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		EditorGUILayout.Space();
		EditorGUILayout.PropertyField(uniqueSynchronization);

		GUI.enabled = uniqueSynchronization.boolValue;
		EditorGUILayout.PropertyField(uniqueSynchronizationId);
		GUI.enabled = true;

		serializedObject.ApplyModifiedProperties();
	}
}
