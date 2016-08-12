using UnityEngine;
using System.Collections.Generic;

public class MouseHandler : MonoBehaviour {
	public delegate void OnMouseDown( GameObject hit );
	public delegate void OnMouseHold( GameObject hit );
	public delegate void OnMouseUp( GameObject hit );

	static List<OnMouseDown> MouseDown = new List<OnMouseDown>();
	static List<OnMouseHold> MouseHold = new List<OnMouseHold>();
	static List<OnMouseUp> MouseUp = new List<OnMouseUp>();

	public Camera camera_ = null;
	bool wasMouseDown_ = false;

	public static void addMouseDown( OnMouseDown cb ) {
		MouseDown.Add(cb);
	}

	public static void addMouseHold( OnMouseHold cb ) {
		MouseHold.Add(cb);
	}

	public static void addMouseUp( OnMouseUp cb ) {
		MouseUp.Add(cb);
	}

	void Awake() {
		if( null == camera_ ) {
			Debug.Log("Camera is null.");
		}
	}

	void Update () {
		bool isMouseDown = Input.GetMouseButton(0);

		if( isMouseDown && !wasMouseDown_ ) {
			var obj = getObjectUnderCursor();
			foreach( var cb in MouseDown ) {
				cb.Invoke(obj);
			}
		} else if( isMouseDown && wasMouseDown_ ) {
			foreach( var cb in MouseHold ) {
				cb.Invoke(null);
			}
		} else if( !isMouseDown && wasMouseDown_ ) {
			var obj = getObjectUnderCursor();
			foreach( var cb in MouseUp ) {
				cb.Invoke(obj);
			}
		}

		wasMouseDown_ = isMouseDown;
	}

	GameObject getObjectUnderCursor() {
		var hit = Physics2D.Raycast(camera_.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		return (null == hit.transform) ? null : hit.transform.gameObject;
	}
}
