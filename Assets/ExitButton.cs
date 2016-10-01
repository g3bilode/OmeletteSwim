using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

	public void Exit(){
		Time.timeScale = 1;
		Application.Quit();
	}
}
