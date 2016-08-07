using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public void startGame() {
		SceneManager.LoadScene("TestScene");
	}

	public void exitGame() {
		Application.Quit ();
	}
}
