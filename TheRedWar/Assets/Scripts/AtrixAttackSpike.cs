using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtrixAttackSpike : MonoBehaviour {
	public float bulletSpeed = 1f;
	public float bulletDamage = 1f;
	public float bulletTimeoutTime = 1f;
	public Rigidbody2D rb;
	
	private void Awake(){
		StartCoroutine(bulletTimeout());
	}
		
	private void FixedUpdate(){
		rb.velocity = transform.up * bulletSpeed;
	}
		
	IEnumerator bulletTimeout() {
		yield return new WaitForSeconds(bulletTimeoutTime);
		Destroy(gameObject);
	}
	
}
