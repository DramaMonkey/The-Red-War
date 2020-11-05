using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{
	GameObject[] pauseObjects;
	
	private void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();
	}
	
	void Update () {

		//uses the escape button to pause and unpause the game
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
				hidePaused();
			}
		}
	}
	
	public void Reload(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	public void pauseControl(){
		if(Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
		} else if (Time.timeScale == 0){
			Time.timeScale = 1;
			hidePaused();
		}
	}
	
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}
	}
		
	public void goToMainMenu(){
		SceneManager.LoadScene("MainMenu");
	}
		
		
	public void hidePaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
	}
	

}
