using UnityEngine;
using System;
using System.Collections.Generic;

public class KanaPopup : MonoBehaviour {
	Fader fader_;
	GameObject colliderObj_;
	KanaAnimation kanaAnimation_;
	TextMesh textMesh_;

	void Start() {
		fader_ = GetComponent<Fader>();
		colliderObj_ = transform.Find("collider").With(x => x.gameObject);
		kanaAnimation_ = transform.Find("kana").With(x => x.GetComponent<KanaAnimation>());
		textMesh_ = transform.Find("text").With(x => x.GetComponent<TextMesh>());
	}

	public void activate() {
		if( null == fader_ || null == colliderObj_ ) {
			Debug.Log("Something is missing.");
		}

		colliderObj_.SetActive(true);
		fader_.fadeIn();
	}

	public void deactivate() {
		if( null == fader_ || null == colliderObj_ || null == kanaAnimation_ ) {
			Debug.Log("Something is missing.");
		}

		colliderObj_.SetActive(false);
		fader_.fadeOut();
		kanaAnimation_.clear();
	}

	public void setKanaType( KanaType type ) {
		if( null == kanaAnimation_ || textMesh_ == null) {
			Debug.Log("Something is missing.");
		}

		textMesh_.text = type.toRomaji();
		kanaAnimation_.configure(Settings.KANA_MODE.toRomaji(), type.toRomaji());
	}
}
