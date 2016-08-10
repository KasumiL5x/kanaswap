using UnityEngine;

public class ChangeKanaMode : MonoBehaviour {
	public KanaHandler KanaHandlerObject;

	public void change( KanaMode mode ) {
		if( null == KanaHandlerObject) {
			Debug.Log ("KanaHandler is not set.");
			return;
		}
		Settings.KANA_MODE = mode;
		KanaHandlerObject.updateAllText ();
		Debug.Log ("KanaMode is now " + mode);
	}
}
