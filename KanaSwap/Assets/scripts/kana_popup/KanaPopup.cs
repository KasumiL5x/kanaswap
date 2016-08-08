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

		text.text = KanaTypeTo.romaji(type);

		switch( type ) {
			case KanaType.A: { animation.configure("hiragana", "a"); break; }
			case KanaType.I: { animation.configure("hiragana", "i"); break; }
			case KanaType.U: { animation.configure("hiragana", "u"); break; }
			case KanaType.E: { animation.configure("hiragana", "e"); break; }
			case KanaType.O: { animation.configure("hiragana", "o"); break; }
			case KanaType.KA: { animation.configure("hiragana", "ka"); break; }
			case KanaType.KI: { animation.configure("hiragana", "ki"); break; }
			case KanaType.KU: { animation.configure("hiragana", "ku"); break; }
			case KanaType.KE: { animation.configure("hiragana", "ke"); break; }
			case KanaType.KO: { animation.configure("hiragana", "ko"); break; }
			case KanaType.SA: { animation.configure("hiragana", "sa"); break; }
			case KanaType.SHI: { animation.configure("hiragana", "shi"); break; }
			case KanaType.SU: { animation.configure("hiragana", "su"); break; }
			case KanaType.SE: { animation.configure("hiragana", "se"); break; }
			case KanaType.SO: { animation.configure("hiragana", "so"); break; }
			case KanaType.TA: { animation.configure("hiragana", "ta"); break; }
			case KanaType.CHI: { animation.configure("hiragana", "chi"); break; }
			case KanaType.TSU: { animation.configure("hiragana", "tsu"); break; }
			case KanaType.TE: { animation.configure("hiragana", "te"); break; }
			case KanaType.TO: { animation.configure("hiragana", "to"); break; }
			case KanaType.NA: { animation.configure("hiragana", "na"); break; }
			case KanaType.NI: { animation.configure("hiragana", "ni"); break; }
			case KanaType.NU: { animation.configure("hiragana", "nu"); break; }
			case KanaType.NE: { animation.configure("hiragana", "ne"); break; }
			case KanaType.NO: { animation.configure("hiragana", "no"); break; }
			case KanaType.HA: { animation.configure("hiragana", "ha"); break; }
			case KanaType.HI: { animation.configure("hiragana", "hi"); break; }
			case KanaType.FU: { animation.configure("hiragana", "fu"); break; }
			case KanaType.HE: { animation.configure("hiragana", "he"); break; }
			case KanaType.HO: { animation.configure("hiragana", "ho"); break; }
			case KanaType.MA: { animation.configure("hiragana", "ma"); break; }
			case KanaType.MI: { animation.configure("hiragana", "mi"); break; }
			case KanaType.MU: { animation.configure("hiragana", "mu"); break; }
			case KanaType.ME: { animation.configure("hiragana", "me"); break; }
			case KanaType.MO: { animation.configure("hiragana", "mo"); break; }
			case KanaType.YA: { animation.configure("hiragana", "ya"); break; }
			case KanaType.YU: { animation.configure("hiragana", "yu"); break; }
			case KanaType.YO: { animation.configure("hiragana", "yo"); break; }
			case KanaType.RA: { animation.configure("hiragana", "ra"); break; }
			case KanaType.RI: { animation.configure("hiragana", "ri"); break; }
			case KanaType.RU: { animation.configure("hiragana", "ru"); break; }
			case KanaType.RE: { animation.configure("hiragana", "re"); break; }
			case KanaType.RO: { animation.configure("hiragana", "ro"); break; }
			case KanaType.WA: { animation.configure("hiragana", "wa"); break; }
			case KanaType.WO: { animation.configure("hiragana", "wo"); break; }
			case KanaType.N: { animation.configure("hiragana", "n"); break; }

			default: {
				Debug.Log("WARNING: Unhandled KanaType in KanaPopup::setKanaType (" + KanaTypeTo.romaji(type) + ").");
				break;
			}
		}
	}
}
