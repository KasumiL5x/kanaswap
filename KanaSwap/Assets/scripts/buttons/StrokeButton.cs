using UnityEngine;

public class StrokeButton : MonoBehaviour {
	public KanaPopup kanaPopup_;
	public KanaSelection kanaSelection_;

	public void onClick() {
		if( null == kanaPopup_ || null == kanaSelection_ ) {
			Debug.Log ("Something is null.");
			return;
		}

		if( kanaSelection_.PrimarySelection != null ) {
			kanaPopup_.activate();
			kanaPopup_.setKanaType(kanaSelection_.PrimarySelection.CurrentType);
		}
	}
}
