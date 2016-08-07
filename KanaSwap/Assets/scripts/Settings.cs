using UnityEngine;
public class Settings {
	public static bool ShowTooltip = true;

	public static void save() {
		Debug.Log("Saving settings.");
		PlayerPrefs.SetInt("ShowTooltip", ShowTooltip ? 1 : 0);
	}

	public static void load() {
		Debug.Log("Loading settings.");
		ShowTooltip = PlayerPrefs.GetInt("ShowTooltip")==1;
	}

	void Awake() {
		load();
	}
}
