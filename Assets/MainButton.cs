using UnityEngine;
using System.Collections;

public class MainButton : MonoBehaviour {

	public void MainMenu(){
		Time.timeScale = 1;
		Application.LoadLevel (0);
	}
}
