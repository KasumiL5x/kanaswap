using UnityEngine;
using UnityEngine.UI;

public class ToggleKanaMode : MonoBehaviour {
	const string ON_TEXT = "Katakana";
	const string OFF_TEXT = "Hiragana";

	void Awake() {
		var toggle = GetComponent<Toggle>();
		toggle.isOn = KanaMode.Katakana == Settings.KANA_MODE;
		toggleTooltip(toggle.isOn);
	}

	public void toggleTooltip( bool val ) {
		// update label text
		transform.Find("Label").With(x => x.GetComponent<UnityEngine.UI.Text>()).text =  val ? ON_TEXT : OFF_TEXT;

		// change actual kana mode
		GameObject.Find("Scripts").With(x => x.GetComponent<ChangeKanaMode>()).change(val ? KanaMode.Katakana : KanaMode.Hiragana);
	}
}
