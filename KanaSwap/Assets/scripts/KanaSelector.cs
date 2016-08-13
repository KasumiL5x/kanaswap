using UnityEngine;

public class KanaSelector : MonoBehaviour {
	public KanaSelection kanaSelection_;
	public KanaHandler kanaHandler_;
	public Camera camera_;
	public GameObject hiliteObject_;

	void Awake() {
		MouseHandler.addMouseDown(onMouseUp);
	}

	void onMouseUp( GameObject hit ) {
		var hitKana = hit.With(x => getKana(x));
		if( null == hitKana ) {
			return;
		}

		// no selection - set primary
		if( null == kanaSelection_.PrimarySelection ) {
			kanaSelection_.PrimarySelection = hitKana;
			hiliteObject_.GetComponent<Fader>().fadeIn();
			hiliteObject_.transform.position = hit.transform.position;
			//Debug.Log ("Selected: " + Utils.getFullPath (kanaSelection_.PrimarySelection.gameObject));
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
			//Debug.Log ("Selected: " + Utils.getFullPath (kanaSelection_.PrimarySelection.gameObject) + " and " + Utils.getFullPath (kanaSelection_.SecondarySelection.gameObject));
			kanaHandler_.swap(kanaSelection_.PrimarySelection, kanaSelection_.SecondarySelection);
			kanaSelection_.PrimarySelection = kanaSelection_.SecondarySelection = null;
			hiliteObject_.GetComponent<Fader>().fadeOut();
		}

		return;
	}

	Kana getKana( GameObject obj ) {
		return obj.GetComponent<Kana>();
	}
}
