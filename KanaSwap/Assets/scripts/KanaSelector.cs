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
			// hilite clicked kana and set it as primary
			hitKana.setHilite(true);
			kanaSelection_.PrimarySelection = hitKana;

			// move and fade in hilite object
			hiliteObject_.transform.position = hit.transform.position;
			hiliteObject_.GetComponent<Fader>().fadeIn();

			//Debug.Log ("Selected: " + Utils.getFullPath (kanaSelection_.PrimarySelection.gameObject));
		}
		// selecting same object - clear selection
		else if( hitKana == kanaSelection_.PrimarySelection ) {
			// remove hilite, nullify primary and secondy selection, then fade out hilite object
			kanaSelection_.PrimarySelection.setHilite(false);
			kanaSelection_.PrimarySelection = kanaSelection_.SecondarySelection = null;
			hiliteObject_.GetComponent<Fader>().fadeOut();
		}
		// selected second object - set secondary
		else {
			kanaSelection_.SecondarySelection = hitKana;
			kanaSelection_.PrimarySelection.setHilite(false); // remove hilite
			kanaHandler_.swap(kanaSelection_.PrimarySelection, kanaSelection_.SecondarySelection);
			kanaSelection_.PrimarySelection = kanaSelection_.SecondarySelection = null;
			hiliteObject_.GetComponent<Fader>().fadeOut();

			//Debug.Log ("Selected: " + Utils.getFullPath (kanaSelection_.PrimarySelection.gameObject) + " and " + Utils.getFullPath (kanaSelection_.SecondarySelection.gameObject));
		}

		return;
	}

	Kana getKana( GameObject obj ) {
		return obj.GetComponent<Kana>();
	}
}
