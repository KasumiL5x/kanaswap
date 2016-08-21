using UnityEngine;

public class HelpButton : MonoBehaviour {
	public MessagePopup message;

	public void onClick() {
		message.show ("Memorize kana by shuffling\nand reordering them! \n\n" +
			"Created as a learning exercise by\nDaniel Green", 999.0f);
	}
}
