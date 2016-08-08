using UnityEngine;
public class Settings {
	public static bool ShowTooltip = true;
	public static float KANA_ANIMATION_SCALE = 10.0f;
	public static KanaMode KANA_MODE = KanaMode.Hiragana;

	public static void save() {
		Debug.Log("Saving settings.");
		PlayerPrefs.SetInt("ShowTooltip", ShowTooltip ? 1 : 0);
		PlayerPrefs.SetString("KanaMode", KANA_MODE.ToString());
	}

	public static void load() {
		Debug.Log("Loading settings.");
		ShowTooltip = PlayerPrefs.GetInt("ShowTooltip")==1;
		KANA_MODE = (KanaMode)System.Enum.Parse(typeof(KanaMode), PlayerPrefs.GetString("KanaMode"));
	}

	void Awake() {
		load();
	}
}
