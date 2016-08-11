using UnityEngine;

public class KanaPopupController : MonoBehaviour {
	public GameObject PopupObject = null;
	KanaPopup kanaPopup_ = null;
	Kana kana_ = null;
	bool isMouseOver_ = false;

	void Start () {
		if( null == PopupObject ) {
			Debug.Log("PopupObject is null.");
			return;
		}

		kanaPopup_ = PopupObject.GetComponent<KanaPopup>();
		kana_ = GetComponent<Kana>();
	}

	void OnMouseUp() {
		if( !isMouseOver_ ) {
			return;
		}

		if( null == PopupObject || null == kanaPopup_ || null == kana_ ) {
			Debug.Log("Objects missing.");
			return;
		}

		kanaPopup_.activate();
		kanaPopup_.setKanaType(kana_.CurrentType);
	}

	void OnMouseEnter() {
		isMouseOver_ = true;
	}

	void OnMouseExit() {
		isMouseOver_ = false;
	}
}
