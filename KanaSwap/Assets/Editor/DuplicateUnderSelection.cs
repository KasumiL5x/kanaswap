using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEditor.SceneManagement;

public class DuplicateUnderSelection : EditorWindow {
	GameObject objToDupe_ = null;

	[MenuItem("Selection/Duplicate Under Selection")]
	static void Init() {
		DuplicateUnderSelection window = (DuplicateUnderSelection)EditorWindow.GetWindow(typeof(DuplicateUnderSelection), false, "Duplicate Under Selection");
		window.Show();
	}

	void doWork() {
		bool doneAnything = false;
		foreach( GameObject obj in Selection.GetFiltered(typeof(GameObject), SelectionMode.ExcludePrefab) ) {
			var dupe = (GameObject)GameObject.Instantiate(objToDupe_);
			dupe.name = objToDupe_.name;
			dupe.transform.SetParent(obj.transform);
			dupe.transform.localPosition = objToDupe_.transform.localPosition;
			dupe.transform.localRotation = objToDupe_.transform.localRotation;
			doneAnything = true;
		}

		if( doneAnything ) {
			EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
		}
	}

	void OnGUI() {
		objToDupe_ = (GameObject)EditorGUI.ObjectField (new Rect (10, 10, position.width - 20, 20), "Object to Duplicate", objToDupe_, typeof(GameObject), true);
		GUI.enabled = objToDupe_ != null;
		if( GUI.Button(new Rect (10, 40, position.width - 20, 20), "Duplicate under Selected") ) {
			doWork();
		}
		GUI.enabled = true;
	}
}
