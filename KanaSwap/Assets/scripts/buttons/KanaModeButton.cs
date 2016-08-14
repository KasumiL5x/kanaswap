using UnityEngine;

public class KanaModeButton : MonoBehaviour {
	void Awake() {
		updateKanaMode(Settings.KANA_MODE);
		updateText();
	}

	void updateText() {
		var kanaModeText = KanaMode.Hiragana == Settings.KANA_MODE ? "ひ" : "カ";
		transform.Find ("Text").With (x => x.GetComponent<UnityEngine.UI.Text> ()).Do (x => x.text = kanaModeText);
	}

	void updateKanaMode( KanaMode mode ) {
		var changeKanaMode = GameObject.Find("Scripts").With(x => x.GetComponent<ChangeKanaMode>());
		if( null == changeKanaMode ) {
			Debug.Log("Could not find ChangeKanaMode on Scripts object.");
			return;
		}
		changeKanaMode.change(mode);
	}

	public void onClick() {
		updateKanaMode(KanaMode.Hiragana == Settings.KANA_MODE ? KanaMode.Katakana : KanaMode.Hiragana);
		updateText();
	}
}
