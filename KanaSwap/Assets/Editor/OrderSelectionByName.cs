using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

public class OrderSelectionByName : ScriptableWizard {
	[MenuItem("Selection/Order By Name")]
	static void static_OrderByName() {
		// get selection
		List<Transform> selection = new List<Transform>();
		foreach( GameObject obj in Selection.GetFiltered(typeof(GameObject), SelectionMode.ExcludePrefab)) {
			selection.Add(obj.transform);
		}

		// sort by name and reverse
		var sorted = selection.OrderBy(x => x.transform.name).ToList();
		sorted.Reverse();

		// set all to 0; unity will auto increment
		foreach( var obj in sorted ) {
			obj.SetSiblingIndex(0);
		}
	}
}
