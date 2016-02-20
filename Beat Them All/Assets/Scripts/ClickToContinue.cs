using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickToContinue : MonoBehaviour {

	public string scene;

	private bool loadLock;

	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !loadLock)
			LoadScene ();
	}

	void LoadScene(){
		loadLock = true;
        SceneManager.LoadScene(scene);
	}
}
