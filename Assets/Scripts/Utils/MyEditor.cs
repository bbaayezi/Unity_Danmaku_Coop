using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(EnemyMotionController))]
public class MyEditor : Editor {
	public override void OnInspectorGUI() {
		var myScript = target as EnemyMotionController;
		serializedObject.Update();
		List<string> excludedList = new List<string>();

		if (myScript.UsePresets)
		{
			excludedList.Add("MotionClips");
			excludedList.Add("MotionConfigs");
			if (myScript.Pre1)
			{
				excludedList.Add("Pre2");
				excludedList.Add("Pre3");
				excludedList.Add("Pre4");
			}
			else if (myScript.Pre2)
			{
				excludedList.Add("Pre1");
				excludedList.Add("Pre3");
				excludedList.Add("Pre4");
			}
			else if (myScript.Pre3)
			{
				excludedList.Add("Pre1");
				excludedList.Add("Pre2");
				excludedList.Add("Pre4");
			}
			else if (myScript.Pre4)
			{
				excludedList.Add("Pre1");
				excludedList.Add("Pre2");
				excludedList.Add("Pre3");
			}
		}
		if (!myScript.UsePresets)
		{
			excludedList.Add("Pre1");
			excludedList.Add("Pre2");
			excludedList.Add("Pre3");
			excludedList.Add("Pre4");
		}
		DrawPropertiesExcluding(serializedObject, propertyToExclude: excludedList.ToArray());
		serializedObject.ApplyModifiedProperties();
	}
}