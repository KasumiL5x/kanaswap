using UnityEngine;
using UnityEngine.UI;

public class ToggleTooltip : MonoBehaviour {
	void Start() {
		GetComponent<Toggle>().isOn = Settings.ShowTooltip;
	}

	public void toggleTooltip( bool val ) {
		Debug.Log("Toggled: " + val);
		Settings.ShowTooltip = val;
		Settings.save();
	}
}
