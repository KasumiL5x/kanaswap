using UnityEngine;

public class Kana : MonoBehaviour {
	public KanaType ActualType = KanaType.Invalid;
	public KanaType CurrentType = KanaType.Invalid;

	public void forceUpdateText() {
		var textMesh = GetComponent<TextMesh>();
		if( null == textMesh ) {
			Debug.Log("TextMesh is missing from " + Utils.getFullPath (gameObject));
			return;
		}

		textMesh.text = CurrentType.toJapanese();
	}
}