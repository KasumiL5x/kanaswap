using UnityEngine;

public class Kana : MonoBehaviour {
	public KanaType ActualType = KanaType.Invalid;
	public KanaType CurrentType = KanaType.Invalid;

	Color DefaultColor   = new Color(0.8f, 0.75f, 0.71f, 1.0f); // #cdc0b4
	Color IncorrectColor = new Color(0.6f, 0.56f, 0.50f, 1.0f); // #998e7f
	Color HiliteColor    = new Color(0.8f, 0.79f, 0.77f, 1.0f); // #ccc9c5
	bool hilited_ = false;

	float ColorLerpTime = 0.15f;
	float timerColorLerp_ = 0.0f;
	bool isLerpingColor_ = false;
	Color lastColor_;
	Color desiredColor_;
	SpriteRenderer bgRenderer_;

	public Kana() {
		timerColorLerp_ = ColorLerpTime;
		lastColor_ = desiredColor_ = DefaultColor;
	}

	void Awake() {
		bgRenderer_ = transform.Find("bg").With(x => x.GetComponent<SpriteRenderer>());
		bgRenderer_.Do(x => x.color = desiredColor_);

		updateColor();
	}

	void Update() {
		if( isLerpingColor_ ) {
			timerColorLerp_ -= Time.deltaTime;

			timerColorLerp_ = (timerColorLerp_ < 0.0f) ? 0.0f : timerColorLerp_;
			Color newColor = Color.Lerp(lastColor_, desiredColor_, 1.0f - (timerColorLerp_ / ColorLerpTime));
			bgRenderer_.color = newColor;

			if( timerColorLerp_ <= 0.0f ) {
				timerColorLerp_ = ColorLerpTime;
				isLerpingColor_ = false;
			}
		}
	}

	public bool isCorrect() {
		return CurrentType == ActualType;
	}

	public void forceUpdateText() {
		var textMesh = GetComponent<TextMesh>();
		if( null == textMesh ) {
			Debug.Log("TextMesh is missing from " + Utils.getFullPath (gameObject));
			return;
		}
		textMesh.text = CurrentType.toJapanese();
	}

	public void setHilite( bool hilited ) {
		hilited_ = hilited;
		updateColor();
	}

	public void reset() {
		CurrentType = ActualType;
		updateColor();
	}

	public void updateColor() {
		lastColor_ = bgRenderer_.color;
		desiredColor_ = hilited_ ? HiliteColor : (isCorrect() ? DefaultColor : IncorrectColor);
		timerColorLerp_ = ColorLerpTime;
		isLerpingColor_ = true;
	}
}