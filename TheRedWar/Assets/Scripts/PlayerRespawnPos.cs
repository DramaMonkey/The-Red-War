using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnPos : MonoBehaviour {
	private static GameMaster instanceGameMaster;
	
	void Start(){
		instanceGameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		transform.position = instanceGameMaster.lastCheckPointPos;
	}
}
