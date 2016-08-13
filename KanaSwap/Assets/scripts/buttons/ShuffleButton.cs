using UnityEngine;
using System.Collections;

public class ShuffleButton : MonoBehaviour {
	public KanaHandler handler;
	public MessagePopup message;

	public void onClick() {
		if( null == handler ) {
			Debug.Log("KanaHandler not set.");
			return;
		}

		if( null == message ) {
			Debug.Log("MessagePopup not set.");
			return;
		}

		handler.shuffle();
		message.show("Organize the kana.\nTap to select, tap again to swap.", 3.0f);
	}
}
