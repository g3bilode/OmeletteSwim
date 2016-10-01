using UnityEngine;
using System.Collections;

public class StartGameController : MonoBehaviour {

	public GameObject controlScreen;
	bool controlsShown = false;
	
	void Update(){
		if (controlsShown) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				controlScreen.SetActive (false);
				controlsShown = false;
			}
		}
	}

	public void showControls(){
		controlScreen.SetActive (! controlsShown);
		controlsShown = ! controlsShown;
	}
}
