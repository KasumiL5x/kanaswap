using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

public class ReverseHierarchy : ScriptableWizard {
	[MenuItem("Selection/Reverse Hiearrchy")]
	static void static_ReverseHierarchy() {
		List<Transform> selection = new List<Transform>();
		foreach( GameObject obj in Selection.GetFiltered(typeof(GameObject), SelectionMode.ExcludePrefab)) {
			selection.Add(obj.transform);
		}

		// sort by sibling index from lowest to highest
		selection.Sort( (a, b) => a.GetSiblingIndex() < b.GetSiblingIndex() ? -1 : 1 );

		// flip values
		for( int i = 0; i < selection.Count/2; ++i ) {
			int firstIndex = selection[i].GetSiblingIndex();
			int lastIndex = selection[selection.Count-1-i].GetSiblingIndex();

			selection[i].SetSiblingIndex(lastIndex);
			selection[selection.Count-1-i].SetSiblingIndex(firstIndex);
		}
	}

}
