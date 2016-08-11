using UnityEngine;
using System.Collections.Generic;

public class MouseHandler : MonoBehaviour {
	public delegate void OnMouseDown( GameObject hit );
	public delegate void OnMouseHold( GameObject hit );
	public delegate void OnMouseUp( GameObject hit );

	public delegate bool OnMouseDownB( GameObject hit );
	public delegate bool OnMouseHoldB( GameObject hit );
	public delegate bool OnMouseUpB( GameObject hit );

	static List<OnMouseDown> MouseDown = new List<OnMouseDown>();
	static List<OnMouseHold> MouseHold = new List<OnMouseHold>();
	static List<OnMouseUp> MouseUp = new List<OnMouseUp>();

	static List<OnMouseDownB> MouseDownB = new List<OnMouseDownB>();
	static List<OnMouseHoldB> MouseHoldB = new List<OnMouseHoldB>();
	static List<OnMouseUpB> MouseUpB = new List<OnMouseUpB>();

	static GameObject ClickedObject = null;
	public Camera camera_ = null;
	bool wasMouseDown_ = false;

	public static void addMouseDown( OnMouseDown cb ) {
		MouseDown.Add(cb);
	}

	public static void addMouseDownB( OnMouseDownB cb ) {
		MouseDownB.Add(cb);
	}

	public static void addMouseHold( OnMouseHold cb ) {
		MouseHold.Add(cb);
	}

	public static void addMouseHoldB( OnMouseHoldB cb ) {
		MouseHoldB.Add(cb);
	}

	public static void addMouseUp( OnMouseUp cb ) {
		MouseUp.Add(cb);
	}

	public static void addMouseUpB( OnMouseUpB cb ) {
		MouseUpB.Add(cb);
	}

	void Awake() {
		if( null == camera_ ) {
			Debug.Log("Camera is null.");
		}
	}

	void Update () {
		bool isMouseDown = Input.GetMouseButton(0);

		if( isMouseDown && !wasMouseDown_ ) {
			updateClickedObject();
			foreach( var cb in MouseDown ) {
				cb.Invoke(ClickedObject);
			}
			foreach( var cb in MouseDownB ) {
				if( cb.Invoke(ClickedObject) ) {
					break;
				}
			}
		} else if( isMouseDown && wasMouseDown_ ) {
			foreach( var cb in MouseHold ) {
				cb.Invoke(ClickedObject);
			}
			foreach( var cb in MouseHoldB ) {
				if( cb.Invoke(ClickedObject) ) {
					break;
				}
			}
		} else if( !isMouseDown && wasMouseDown_ ) {
			updateClickedObject();
			foreach( var cb in MouseUp ) {
				cb.Invoke(ClickedObject);
			}
			foreach( var cb in MouseUpB ) {
				if( cb.Invoke(ClickedObject) ) {
					break;
				}
			}
		}

		wasMouseDown_ = isMouseDown;
	}

	void updateClickedObject() {
		var hit = Physics2D.Raycast(camera_.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		ClickedObject = null == hit.transform ? null : hit.transform.gameObject;
	}
}
