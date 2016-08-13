using UnityEngine;
using System.Collections;

public class MessagePopup : MonoBehaviour {
	Fader fader_;
	TextMesh textMesh_;
	GameObject collider_;
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

		collider_ = transform.Find("collider").With(x => x.gameObject);
		if( null == collider_ ) {
			Debug.Log("Missing collider.");
		}

		MouseHandler.addMouseDown(onMouseDown);
	}

	void Update() {
		if( !isAlive_ ) {
			return;
		}

		timer_ -= Time.deltaTime;
		if( timer_ <= 0.0f ) {
			fader_.fadeOut();
			isAlive_ = false;
			collider_.SetActive(false);
		}
	}

	public void show( string text, float time=1.0f ) {
		textMesh_.text = text;
		fader_.fadeIn();
		timer_ = time;
		isAlive_ = true;
		collider_.SetActive(true);
	}

	void onMouseDown( GameObject hit ) {
		if( collider_ != hit ) {
			return;
		}
		timer_ = 0.0f;
		Debug.Log ("Hit: " + Utils.getFullPath (hit));
	}
}
