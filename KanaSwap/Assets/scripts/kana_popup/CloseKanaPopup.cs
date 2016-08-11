using UnityEngine;
using System.Collections;

public class CloseKanaPopup : MonoBehaviour {
	public KanaPopup popup_ = null;

	void Awake() {
		MouseHandler.addMouseDownB(onMouseDown);
	}

	bool onMouseDown( GameObject hit ) {
		if( null == hit ) {
			return false;
		}

		if( gameObject != hit ) {
			return false;
		}

		if( null == popup_ ) {
			Debug.Log("Missing popup.");
			return false;
		}

		popup_.deactivate();

		return true;
	}
}
