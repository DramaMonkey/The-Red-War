using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	private static GameMaster instanceGameMaster;
	public Vector2 lastCheckPointPos;
	public Transform LevelStart;
	public string selectedCharacter;
	[HideInInspector]
	public bool restartSpawnPos;
	

    void Awake() {
        if(instanceGameMaster == null) { 
			instanceGameMaster = this;
			DontDestroyOnLoad(instanceGameMaster);
		} else {
			Destroy(this);
		}

		
		//check if need to restart spawn pos - ie coming from main menu
		if(instanceGameMaster.restartSpawnPos == true) {
			LevelStart = GameObject.FindGameObjectWithTag("LevelStart").GetComponent<Transform>();
			instanceGameMaster.lastCheckPointPos = LevelStart.position;
			instanceGameMaster.restartSpawnPos = false;
		}
		
		//set selected character to default character
		selectedCharacter = "default";
		
    }
	
	
}
