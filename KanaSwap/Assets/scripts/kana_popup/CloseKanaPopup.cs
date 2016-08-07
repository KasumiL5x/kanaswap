using UnityEngine;
using System.Collections;

public class CloseKanaPopup : MonoBehaviour {
	public KanaPopup popup_ = null;

	void OnMouseDown() {
		if( null == popup_ ) {
			Debug.Log("Missing popup.");
			return;
		}

		popup_.deactivate();
	}
}
