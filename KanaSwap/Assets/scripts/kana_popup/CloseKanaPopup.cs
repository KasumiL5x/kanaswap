using UnityEngine;
using System.Collections;

public class CloseKanaPopup : MonoBehaviour {
	public KanaPopup popup_ = null;
	public KanaSelector kanaSelector_;

	void Awake() {
		MouseHandler.addMouseDown(onMouseDown);
	}

	void onMouseDown( GameObject hit ) {
		if( null == hit ) {
			return;
		}

		if( gameObject != hit ) {
			return;
		}

		if( null == popup_ || null == kanaSelector_ ) {
			Debug.Log("Missing something.");
			return;
		}
		popup_.deactivate();
		kanaSelector_.clearSelection();
	}
}
