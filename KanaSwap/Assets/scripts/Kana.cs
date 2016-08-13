using UnityEngine;

public class Kana : MonoBehaviour {
	public KanaType ActualType = KanaType.Invalid;
	public KanaType CurrentType = KanaType.Invalid;
	Color DefaultColor = new Color(0.8f, 0.75f, 0.71f, 1.0f); // #cdc0b4
	Color IncorrectColor = new Color(0.6f, 0.56f, 0.50f, 1.0f); // #998e7f
	Color HiliteColor = new Color(0.8f, 0.79f, 0.77f, 1.0f);// #ccc9c5
	bool hilited_ = false;

	void Awake() {
		updateColor();
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
		Color color = hilited_ ? HiliteColor : (isCorrect() ? DefaultColor : IncorrectColor);
		transform.Find("bg").With(x => x.GetComponent<SpriteRenderer>()).Do(x => x.color = color);
	}
}