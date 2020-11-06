using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
	
	private GameMaster gm;
	private SpriteRenderer spriteRenderer; 
	public Sprite checkpointOn;
	public Sprite checkpointOff;
	
	GameObject[] allCheckpoints;
	
	void Start(){
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		
		allCheckpoints = GameObject.FindGameObjectsWithTag("checkpoint");
	}
	
    private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player")){
			gm.lastCheckPointPos = transform.position;
			
			foreach(GameObject c in allCheckpoints){
				c.gameObject.GetComponent<Checkpoint>().setCheckpointStatus(false);
			}
			setCheckpointStatus(true);

		}
    }
	
	public void setCheckpointStatus(bool setStatus){
		if(setStatus == true){
			spriteRenderer.sprite = checkpointOn;
		} else if (setStatus == false){
			spriteRenderer.sprite = checkpointOff;
		}
	}
	
}
