using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	public void RestartGame(){
		Time.timeScale = 1;
		Application.LoadLevel (Application.loadedLevel);
	}
}
