using UnityEngine;

public class KanaSelector : MonoBehaviour {
	public KanaSelection kanaSelection_;
	public KanaHandler kanaHandler_;
	public Camera camera_;
	public GameObject hiliteObject_;
	bool wasPressed_ = false;

	void Update () {
		if( null == kanaSelection_ || null == camera_ || null == hiliteObject_ || null == kanaHandler_ ) {
			Debug.Log("Something was null.");
			return;
		}

		bool isPressed = Input.GetAxis("Fire1") > 0.0f;
		bool onUp = !isPressed && wasPressed_;
		wasPressed_ = isPressed;

		if( onUp ) {
			// what did we hit?
			var hit = Physics2D.Raycast(camera_.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			// if hit nothing, clear selection
			if( null == hit.transform ) {
				return;
			}

			// get Kana of hit object
			var hitKana = getKana(hit.transform.gameObject);
			if( null == hitKana ) { // is not a Kana object
				return;
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
		}
	}

	Kana getKana( GameObject obj ) {
		return obj.GetComponent<Kana>();
	}
}
