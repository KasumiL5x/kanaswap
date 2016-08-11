using UnityEngine;
using System.Collections;

public class ShuffleButton : MonoBehaviour {
	public KanaHandler handler;

	public void onClick() {
		if( null == handler ) {
			Debug.Log("KanaHandler not set.");
			return;
		}

		handler.shuffle();
	}
}
