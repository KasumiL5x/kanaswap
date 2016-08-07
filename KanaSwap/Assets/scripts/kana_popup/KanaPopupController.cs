using UnityEngine;

public class KanaPopupController : MonoBehaviour {
	public GameObject PopupObject = null;
	KanaPopup kanaPopup_ = null;
	Kana kana_ = null;

	void Start () {
		if( null == PopupObject ) {
			Debug.Log("PopupObject is null.");
			return;
		}

		kanaPopup_ = PopupObject.GetComponent<KanaPopup>();
		kana_ = GetComponent<Kana>();
	}

	void OnMouseDown() {
		if( null == PopupObject || null == kanaPopup_ || null == kana_ ) {
			Debug.Log("Objects missing.");
			return;
		}

		kanaPopup_.activate();
		kanaPopup_.setKanaType(kana_.Type);
	}
}
