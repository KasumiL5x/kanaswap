using UnityEngine;

public class ButtonColor : MonoBehaviour {
	public UnityEngine.UI.Text text;
	public Color PressedColor = new Color(0.74f, 0.68f, 0.63f, 1.0f);
	public Color ReleasedColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

	public void onButtonClick() {
		if( text != null ) {
			text.color = PressedColor;
		}
	}

	public void onButtonRelease() {
		if( text != null ) {
			text.color = ReleasedColor;
		}
	}
}
