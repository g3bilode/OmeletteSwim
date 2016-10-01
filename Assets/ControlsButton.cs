using UnityEngine;
using System.Collections;

public class ControlsButton : MonoBehaviour {

	public void ShowControls(){
		StartGameController gameController = GameObject.Find("GameController").GetComponent<StartGameController>();
		gameController.showControls ();
	}



}
