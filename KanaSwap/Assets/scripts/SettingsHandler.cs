using UnityEngine;
using System.Collections;

public class SettingsHandler : MonoBehaviour {
	void Awake() {
		Settings.load();
	}

	void OnApplicationQuit() {
		Settings.save();
	}
}
