using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

	public void loadNewScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void resetScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
