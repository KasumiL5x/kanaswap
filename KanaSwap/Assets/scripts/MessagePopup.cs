using UnityEngine;
using System.Collections;

public class MessagePopup : MonoBehaviour {
	Fader fader_;
	TextMesh textMesh_;
	float timer_ = 0.0f;
	bool isAlive_ = false;

	void Awake() {
		fader_ = gameObject.GetComponent<Fader>();
		if( null == fader_ ) {
			Debug.Log("Missing Fader.");
		}

		textMesh_ = transform.Find("text").With(x => x.GetComponent<TextMesh>());
		if( null == textMesh_ ) {
			Debug.Log("Missing TextMesh.");
		}
	}

	void Update() {
		if( !isAlive_ ) {
			return;
		}

		timer_ -= Time.deltaTime;
		if( timer_ <= 0.0f ) {
			fader_.fadeOut();
			isAlive_ = false;
		}
	}

	public void show( string text, float time=1.0f ) {
		gameObject.SetActive(true);
		fader_.fadeIn();
		timer_ = time;
		isAlive_ = true;
	}
}
