using UnityEngine;

public class DragDrop : MonoBehaviour {
	public Camera camera_;
	public KanaHandler handler_;
	GameObject draggingObject_;

	void Update () {
		bool pressed = Input.GetAxis("Fire1") > 0.0f;


		if( pressed && null == draggingObject_ ) { // initial press w/ no currently dragged object
			var obj = getObjectUnderCursor();
			if( obj != null && isKana(obj) ) {
				draggingObject_ = obj;
				Debug.Log("Now dragging: " + Utils.getFullPath(obj));
			}
		} else if( pressed && draggingObject_ != null ) { // still pressed while dragging an object
			// todo: update some kind of animation
			//Debug.Log("Currently dragging: " + Utils.getFullPath(draggingObject_));
		} else if( !pressed && draggingObject_ != null ) { // released w/ an object being dragged
			var obj = getObjectUnderCursor();
			if( obj != null && isKana(obj) ) {
				// flip two
				var kanaDrag = draggingObject_.GetComponent<Kana>();
				var kanaDrop = obj.GetComponent<Kana>();
				handler_.swap(kanaDrag, kanaDrop);
			}

			draggingObject_ = null;
			Debug.Log("Reset drag");
		} else {
			// nothing
		}
			
//		if( pressed ) {
//			var hit = Physics2D.Raycast(camera_.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
//			if( hit.collider != null ) {
//				Debug.Log ("Clicked: " + Utils.getFullPath(hit.transform.gameObject));
//			}
//		}


	}

	bool isKana( GameObject obj ) {
		return obj.GetComponent<Kana>() != null;
	}

	GameObject getObjectUnderCursor() {
		var hit = Physics2D.Raycast(camera_.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		return null == hit.transform ? null : hit.transform.gameObject;
	}
}
