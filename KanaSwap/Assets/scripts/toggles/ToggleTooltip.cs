using UnityEngine;
using UnityEngine.UI;

public class ToggleTooltip : MonoBehaviour {
	void Awake() {
		GetComponent<Toggle>().isOn = Settings.ShowTooltip;
	}

	public void toggleTooltip( bool val ) {
		Settings.ShowTooltip = val;
	}
}
