using UnityEngine;
using System.Collections;

public class KanaTooltipController : MonoBehaviour {
	public GameObject TooltipObject = null;
	Fader fader_ = null;
	Kana kana_ = null;

	void Start () {
		fader_ = TooltipObject.With(x => x.GetComponent<Fader>());
		kana_ = GetComponent<Kana>();
	}
	
	void Update () {

	}

	void OnMouseEnter() {
		if( null == TooltipObject || null == fader_ || null == kana_ ) {
			Debug.Log("Objects missing.");
			return;
		}

		if( Settings.ShowTooltip ) {
			fader_.fadeIn();

			TooltipObject.transform.Find("text").With(x => x.GetComponent<TextMesh>()).text = kana_.CurrentType.toRomaji();

			var pos = transform.position;
			var offset = new Vector3(0.0f, TooltipObject.transform.lossyScale.y * 2.0f + 0.1f, 0.0f);
			TooltipObject.transform.position = new Vector3(pos.x, pos.y, TooltipObject.transform.position.z) + offset;
		}
	}

	void OnMouseExit() {
		if( null == TooltipObject || null == fader_ || null == kana_ ) {
			Debug.Log("Objects missing.");
			return;
		}

		if( Settings.ShowTooltip ) {
			fader_.fadeOut();
		}
	}
}
