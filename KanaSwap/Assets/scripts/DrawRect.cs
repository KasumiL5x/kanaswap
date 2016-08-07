using UnityEngine;
using System.Collections;

public class DrawRect : MonoBehaviour {
	Sprite sprite_ = null;

	void Start () {
		Texture2D tex = new Texture2D(1, 1, TextureFormat.ARGB32, false);
		tex.SetPixel(0, 0, new Color(0.0f, 0.0f, 0.0f, 0.75f));
		tex.Apply();
		sprite_ = Sprite.Create(tex, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f));

		GetComponent<SpriteRenderer>().sprite = sprite_;
	}
}
