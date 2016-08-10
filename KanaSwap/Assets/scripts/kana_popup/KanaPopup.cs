using UnityEngine;
using System;
using System.Collections.Generic;

public class KanaPopup : MonoBehaviour {
	Fader fader_ = null;

	void Start() {
		fader_ = GetComponent<Fader>();
	}

	public void activate() {
		transform.Find("collider").gameObject.SetActive(true);
		fader_.fadeIn();
	}

	public void deactivate() {
		transform.Find("collider").gameObject.SetActive(false);
		fader_.fadeOut();

		var animation = transform.Find("kana").gameObject.GetComponent<KanaAnimation>();
		if( null == animation ) {
			Debug.Log("KanaAnimation is null.");
			return;
		}
		animation.clear();
	}

	public void setKanaType( KanaType type ) {
		var text = transform.Find("text").gameObject.GetComponent<TextMesh>();
		if( null == text ) {
			Debug.Log("TextMesh is null.");
			return;
		}

		var animation = transform.Find("kana").gameObject.GetComponent<KanaAnimation>();
		if( null == animation ) {
			Debug.Log("KanaAnimation is null.");
			return;
		}

		text.text = type.toRomaji();

		string mode = Settings.KANA_MODE.toRomaji();
		string character = type.toRomaji();
		animation.configure(mode, character);
	}
}
