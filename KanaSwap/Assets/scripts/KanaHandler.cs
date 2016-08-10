using UnityEngine;

public class KanaHandler : MonoBehaviour {
	public void updateAllText() {
		foreach( Transform xform in transform ) {
			var kana = xform.gameObject.GetComponent<Kana>();
			if( null == kana ) {
				Debug.Log (Utils.getFullPath (xform.gameObject) + " is missing a Kana.");
				continue;
			}

			kana.forceUpdateText();
		}
	}
}
