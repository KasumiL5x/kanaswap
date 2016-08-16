using UnityEngine;

public class KanaTooltip : MonoBehaviour {
	Fader fader_;
	TextMesh text_;
	public GameObject ActiveKana {get; private set;}

	void Start() {
		fader_ = gameObject.GetComponent<Fader>();
		text_ = transform.Find("text").With(x => x.GetComponent<TextMesh>());
	}

	public void activate( string text, Vector3 position, GameObject caller ) {
		if( null == fader_ || null == text_ ) {
			Debug.Log("Objects missing.");
			return;
		}

		ActiveKana = caller;

		fader_.fadeIn();
		text_.text = text;

		var offset = transform.lossyScale.y * 2.0f + 0.1f;
		transform.position = new Vector3(position.x, position.y + offset, transform.position.z);
	}

	public void updateText( string text ) {
		if( null == fader_ || null == text_ ) {
			Debug.Log("Objects missing.");
			return;
		}
		text_.text = text;
	}

	public void deactivate() {
		if( null == fader_ || null == text_ ) {
			Debug.Log("Objects missing.");
			return;
		}

		fader_.fadeOut();

		ActiveKana = null;
	}
}
