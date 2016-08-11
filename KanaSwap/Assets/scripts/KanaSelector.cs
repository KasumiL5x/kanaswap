using UnityEngine;

public class KanaSelector : MonoBehaviour {
	public KanaSelection kanaSelection_;
	public KanaHandler kanaHandler_;
	public Camera camera_;
	public GameObject hiliteObject_;

	void Awake() {
		MouseHandler.addMouseDownB(onMouseUp);
	}

	bool onMouseUp( GameObject hit ) {
		if( null == hit ) {
			return false;
		}

		var hitKana = getKana(hit);
		if( null == hitKana ) {
			return false;
		}

		// no selection - set primary
		if( null == kanaSelection_.PrimarySelection ) {
			kanaSelection_.PrimarySelection = hitKana;
			hiliteObject_.GetComponent<Fader>().fadeIn();
			hiliteObject_.transform.position = hit.transform.position;
			Debug.Log ("Selected: " + Utils.getFullPath (kanaSelection_.PrimarySelection.gameObject));
		}
		// selecting same object - clear selection
		else if( hitKana == kanaSelection_.PrimarySelection ) {
			// if selecting the same, just clear the selection
			kanaSelection_.PrimarySelection = kanaSelection_.SecondarySelection = null;
			hiliteObject_.GetComponent<Fader>().fadeOut();
		}
		// selected second object - set secondary
		else {
			kanaSelection_.SecondarySelection = hitKana;
			Debug.Log ("Selected: " + Utils.getFullPath (kanaSelection_.PrimarySelection.gameObject) + " and " + Utils.getFullPath (kanaSelection_.SecondarySelection.gameObject));
			kanaHandler_.swap(kanaSelection_.PrimarySelection, kanaSelection_.SecondarySelection);
			kanaSelection_.PrimarySelection = kanaSelection_.SecondarySelection = null;
			hiliteObject_.GetComponent<Fader>().fadeOut();
		}

		return true;
	}

	Kana getKana( GameObject obj ) {
		return obj.GetComponent<Kana>();
	}
}
