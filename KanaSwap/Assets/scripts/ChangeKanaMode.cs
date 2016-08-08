using UnityEngine;

public class ChangeKanaMode : MonoBehaviour {
	public GameObject HiraganaGrid;
	public GameObject KatakanaGrid;

	public void change( KanaMode mode ) {
		if( null == HiraganaGrid || null == KatakanaGrid ) {
			Debug.Log("A grid object was missing.");
			return;
		}

		Settings.KANA_MODE = mode;

		bool enableHiragana = KanaMode.Hiragana == mode;
		HiraganaGrid.SetActive(enableHiragana);
		KatakanaGrid.SetActive(!enableHiragana);


		Debug.Log ("KanaMode is now " + mode);

		// todo: tweak objects accordingly
	}
}
