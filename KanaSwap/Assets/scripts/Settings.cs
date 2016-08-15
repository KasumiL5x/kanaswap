using UnityEngine;
public class Settings {
	public static float KANA_ANIMATION_SCALE = 10.0f;
	public static KanaMode KANA_MODE = KanaMode.Hiragana;

	public static void save() {
		Debug.Log("Saving settings.");
		PlayerPrefs.SetString("KanaMode", KANA_MODE.ToString());
	}

	public static void load() {
		Debug.Log("Loading settings.");
		KANA_MODE = (KanaMode)System.Enum.Parse(typeof(KanaMode), PlayerPrefs.GetString("KanaMode"));
	}

	void Awake() {
		load();
	}
}
