using UnityEngine;

public class DragDrop : MonoBehaviour {
	public Camera camera_;

	void Update () {
		bool pressed = Input.GetAxis("Fire1") > 0.0f;
		if( pressed ) {
			var hit = Physics2D.Raycast(camera_.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			if( hit.collider != null ) {
				Debug.Log ("Clicked: " + Utils.getFullPath(hit.transform.gameObject));
			}
		}
	}
}
