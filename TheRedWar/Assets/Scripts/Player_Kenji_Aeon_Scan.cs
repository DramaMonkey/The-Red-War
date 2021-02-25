using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Kenji_Aeon_Scan : MonoBehaviour {
	
	public GameObject player;
	public float scanTime = 0.3f;
	
	void Start() {
		player = GameObject.FindGameObjectWithTag("Aeon");
		StartCoroutine("scanTimeout");
	}
	
	private void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag == "Enemy"){
			player.GetComponent<Player_Kenji_Aeon_Control>().attack(collision.gameObject);
			Destroy(this.gameObject);
		}
		
	}
	
	
	IEnumerator scanTimeout(){	
		yield return new WaitForSeconds(scanTime);
		Destroy(this.gameObject);
	}
	
}
