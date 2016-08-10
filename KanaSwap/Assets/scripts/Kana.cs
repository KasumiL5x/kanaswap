using UnityEngine;

public class Kana : MonoBehaviour {
	public KanaType Type = KanaType.Invalid;

	public void forceUpdateText() {
		var textMesh = GetComponent<TextMesh>();
		if( null == textMesh ) {
			Debug.Log("TextMesh is missing from " + Utils.getFullPath (gameObject));
			return;
		}

		textMesh.text = Type.toJapanese();
	}
}