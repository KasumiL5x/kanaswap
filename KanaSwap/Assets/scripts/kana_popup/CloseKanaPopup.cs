using UnityEngine;
using System.Collections;

public class CloseKanaPopup : MonoBehaviour {
	public KanaPopup popup_ = null;

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

		if( null == popup_ ) {
			Debug.Log("Missing popup.");
			return;
		}
		popup_.deactivate();
	}
}
