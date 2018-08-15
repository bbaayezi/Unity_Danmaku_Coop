using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyBulletController))]
public class CustomBulletEditor : Editor {
	public bool ToggleGroup;
	public bool Toggle;
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		EditorGUILayout.HelpBox(
			"本组件将提供基本子弹类型的设定。\n其中基本子弹类型包括：" +
			"随机弹，固定弹与自机器狙。\n" +
			"This Components provides basic configurations for bullet types.\n" +
			"Basic bullet type includes:\nRandomShot, FixedShot and AimedShot."
		, MessageType.Info, true);
		serializedObject.Update();
		ToggleGroup = EditorGUILayout.BeginToggleGroup("Config", ToggleGroup);
			EditorGUILayout.Toggle("Toggle", Toggle);
		EditorGUILayout.EndToggleGroup();
		serializedObject.ApplyModifiedProperties();
	}
}