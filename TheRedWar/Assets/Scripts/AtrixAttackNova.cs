using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtrixAttackNova: MonoBehaviour {
	public float bulletTimeoutTime = 1f;
	
	private void Awake(){
		StartCoroutine(bulletTimeout());
	}
	private void Update(){
		transform.Rotate (Vector3.forward * Random.Range(-10, 11));
	}
		
	IEnumerator bulletTimeout() {
		yield return new WaitForSeconds(bulletTimeoutTime);
		Destroy(gameObject);
	}
	
}
