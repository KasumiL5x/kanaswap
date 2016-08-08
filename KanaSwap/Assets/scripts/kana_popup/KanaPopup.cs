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

		switch( type ) {
			case KanaType.A:   { animation.configure(mode, "a"); break; }
			case KanaType.I:   { animation.configure(mode, "i"); break; }
			case KanaType.U:   { animation.configure(mode, "u"); break; }
			case KanaType.E:   { animation.configure(mode, "e"); break; }
			case KanaType.O:   { animation.configure(mode, "o"); break; }
			case KanaType.KA:  { animation.configure(mode, "ka"); break; }
			case KanaType.KI:  { animation.configure(mode, "ki"); break; }
			case KanaType.KU:  { animation.configure(mode, "ku"); break; }
			case KanaType.KE:  { animation.configure(mode, "ke"); break; }
			case KanaType.KO:  { animation.configure(mode, "ko"); break; }
			case KanaType.SA:  { animation.configure(mode, "sa"); break; }
			case KanaType.SHI: { animation.configure(mode, "shi"); break; }
			case KanaType.SU:  { animation.configure(mode, "su"); break; }
			case KanaType.SE:  { animation.configure(mode, "se"); break; }
			case KanaType.SO:  { animation.configure(mode, "so"); break; }
			case KanaType.TA:  { animation.configure(mode, "ta"); break; }
			case KanaType.CHI: { animation.configure(mode, "chi"); break; }
			case KanaType.TSU: { animation.configure(mode, "tsu"); break; }
			case KanaType.TE:  { animation.configure(mode, "te"); break; }
			case KanaType.TO:  { animation.configure(mode, "to"); break; }
			case KanaType.NA:  { animation.configure(mode, "na"); break; }
			case KanaType.NI:  { animation.configure(mode, "ni"); break; }
			case KanaType.NU:  { animation.configure(mode, "nu"); break; }
			case KanaType.NE:  { animation.configure(mode, "ne"); break; }
			case KanaType.NO:  { animation.configure(mode, "no"); break; }
			case KanaType.HA:  { animation.configure(mode, "ha"); break; }
			case KanaType.HI:  { animation.configure(mode, "hi"); break; }
			case KanaType.FU:  { animation.configure(mode, "fu"); break; }
			case KanaType.HE:  { animation.configure(mode, "he"); break; }
			case KanaType.HO:  { animation.configure(mode, "ho"); break; }
			case KanaType.MA:  { animation.configure(mode, "ma"); break; }
			case KanaType.MI:  { animation.configure(mode, "mi"); break; }
			case KanaType.MU:  { animation.configure(mode, "mu"); break; }
			case KanaType.ME:  { animation.configure(mode, "me"); break; }
			case KanaType.MO:  { animation.configure(mode, "mo"); break; }
			case KanaType.YA:  { animation.configure(mode, "ya"); break; }
			case KanaType.YU:  { animation.configure(mode, "yu"); break; }
			case KanaType.YO:  { animation.configure(mode, "yo"); break; }
			case KanaType.RA:  { animation.configure(mode, "ra"); break; }
			case KanaType.RI:  { animation.configure(mode, "ri"); break; }
			case KanaType.RU:  { animation.configure(mode, "ru"); break; }
			case KanaType.RE:  { animation.configure(mode, "re"); break; }
			case KanaType.RO:  { animation.configure(mode, "ro"); break; }
			case KanaType.WA:  { animation.configure(mode, "wa"); break; }
			case KanaType.WO:  { animation.configure(mode, "wo"); break; }
			case KanaType.N:   { animation.configure(mode, "n"); break; }

			default: {
				Debug.Log("WARNING: Unhandled KanaType in KanaPopup::setKanaType (" + type.toRomaji() + ").");
				break;
			}
		}
	}
}
