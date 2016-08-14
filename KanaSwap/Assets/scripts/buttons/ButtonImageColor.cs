using UnityEngine;

public class ButtonImageColor : MonoBehaviour {
	public UnityEngine.UI.RawImage image_;
	public Color PressedColor = new Color(0.74f, 0.68f, 0.63f, 1.0f);
	public Color ReleasedColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

	public void onButtonClick() {
		if( image_ != null ) {
			image_.color = PressedColor;
		}
	}

	public void onButtonRelease() {
		if( image_ != null ) {
			image_.color = ReleasedColor;
		}
	}
}
