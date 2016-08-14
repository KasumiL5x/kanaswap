using UnityEngine;

public class KanaModeButton : MonoBehaviour {
	void Awake() {
		updateText();
	}

	void updateText() {
		var kanaModeText = KanaMode.Hiragana == Settings.KANA_MODE ? "ひ" : "カ";
		transform.Find ("Text").With (x => x.GetComponent<UnityEngine.UI.Text> ()).Do (x => x.text = kanaModeText);
	}

	public void onClick() {
		var changeKanaMode = GameObject.Find("Scripts").With(x => x.GetComponent<ChangeKanaMode>());
		if( null == changeKanaMode ) {
			Debug.Log("Could not find ChangeKanaMode on Scripts object.");
			return;
		}
		changeKanaMode.change(KanaMode.Hiragana == Settings.KANA_MODE ? KanaMode.Katakana : KanaMode.Hiragana);

		updateText();
	}
}
