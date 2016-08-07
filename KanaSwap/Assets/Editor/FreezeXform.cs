using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class FreezeXform : UnityEditor.EditorWindow {
	bool shouldFreezePosition = true;
	bool shouldFreezeRotation = true;
	bool shouldFreezeScale = true;

	[MenuItem("Selection/Freeze Xform")]
	static void Init() {
		FreezeXform window = (FreezeXform)EditorWindow.GetWindow(typeof(FreezeXform), true, "Freeze Xform");
		window.ShowUtility();
	}

    void OnGUI() {
			shouldFreezePosition = EditorGUILayout.Toggle("Position", shouldFreezePosition);
			shouldFreezeRotation = EditorGUILayout.Toggle("Rotation", shouldFreezeRotation);
			shouldFreezeScale = EditorGUILayout.Toggle("Scale", shouldFreezeScale);

			if( GUILayout.Button("Freeze") ) {
				freezeSelected();
			}
    }

    void freezeSelected() {
			// get selection
			List<Transform> selection = new List<Transform>();
			foreach( GameObject obj in Selection.GetFiltered(typeof(GameObject), SelectionMode.ExcludePrefab)) {
				selection.Add(obj.transform);
			}

			HashSet<Transform> parentsToZero = new HashSet<Transform>();

			foreach( var xform in selection ) {
				if( xform.parent != null ) {
					parentsToZero.Add(xform.parent);
				}

				if( shouldFreezePosition ) {
					setLocalPosition(xform);
				}

				if( shouldFreezeScale ) {
					setLocalScale(xform);
				}

				if( shouldFreezeRotation ) {
					setLocalRotation(xform);
				}
			}

			foreach( var xform in parentsToZero ) {
				if( shouldFreezePosition ) {
					xform.localPosition = Vector3.zero;
				}
				if( shouldFreezeScale ) {
					xform.localScale = Vector3.one;
				}
				if( shouldFreezeRotation ) {
					xform.localRotation = Quaternion.identity;
				}
			}
    }

    void setLocalPosition( Transform xform ) {
    	xform.localPosition = xform.parent != null ? xform.position : xform.localPosition;
    }

    void setLocalScale( Transform xform ) {
    	xform.localScale = xform.parent != null ? xform.lossyScale : xform.localScale;
    }

    void setLocalRotation( Transform xform ) {
    	xform.localRotation = xform.parent != null ? xform.rotation : xform.localRotation;
    }

    // Vector3 getFinalPosition( Transform obj ) {
    // 	if( directParentOnly ) {
    // 		return obj.localPosition + (obj.parent != null ? obj.parent.localPosition : Vector3.zero);
    // 	}

    // 	Vector3 result = obj.localPosition;
    // 	Transform curr = obj.parent;
    // 	while( curr != null ) {
    // 		result += curr.localPosition;
    // 		curr = curr.parent;
    // 	}
    // 	return result;
    // }

    // Quaternion getFinalRotation( Transform obj ) {
    // 	if( directParentOnly ) {
    // 		return obj.localRotation * (obj.parent != null ? obj.parent.localRotation : Quaternion.identity);
    // 	}

    // 	Quaternion result = obj.localRotation;
    // 	Transform curr = obj.parent;
    // 	while( curr != null ) {
    // 		result *= curr.localRotation;
    // 		curr = curr.parent;
    // 	}
    // 	return result;
    // }

    // Vector3 getFinalScale( Transform obj ) {
    // 	if( directParentOnly ) {
    // 		return Vector3.Scale(obj.localScale,(obj.parent != null ? obj.parent.localScale : Vector3.one));
    // 	}

    // 	Vector3 result = obj.localScale;
    // 	Transform curr = obj.parent;
    // 	while( curr != null ) {
    // 		result = Vector3.Scale(result, curr.localScale);
    // 		curr = curr.parent;
    // 	}
    // 	return result;
    // }
}
