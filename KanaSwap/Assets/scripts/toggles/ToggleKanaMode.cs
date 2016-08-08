using UnityEngine;
using UnityEngine.UI;

public class ToggleKanaMode : MonoBehaviour {
	const string ON_TEXT = "Katakana";
	const string OFF_TEXT = "Hiragana";

	void Awake() {
		GetComponent<Toggle>().isOn = Settings.KANA_MODE == KanaMode.Katakana;
	}

	public void toggleTooltip( bool val ) {
		var label = transform.Find ("Label");
		if( null == label ) {
			Debug.Log("Missing label.");
			return;
		}
		var text = label.GetComponent<UnityEngine.UI.Text> ();
		if( null == text ) {
			Debug.Log("Label is missing Text component.");
			return;
		}

		text.text = val ? ON_TEXT : OFF_TEXT;
		GameObject.Find("Scripts").GetComponent<ChangeKanaMode>().change(val ? KanaMode.Katakana : KanaMode.Hiragana);
	}
}
