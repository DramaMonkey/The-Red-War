using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float bulletSpeed = 15f;
	public float bulletDamage = 1f;
	public float bulletTimeoutTime = 1f;
	public Rigidbody2D rb;
	
	private void Awake(){
		StartCoroutine(bulletTimeout());
	}
	
	private void FixedUpdate(){
		rb.velocity = transform.right * bulletSpeed;
	}
	
	private void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag != "Player"){
			Destroy(gameObject);
		}
		if(collision.gameObject.tag == "Enemy"){
			collision.gameObject.GetComponent<EnemyHealth>().AddjustCurrentHealth(-bulletDamage);
			/*if(collision.gameObject.GetComponent<EnemyHealth>().curHealth <= 0){
				Destroy(collision.gameObject);
			}*/
		}
	}
	
	
	IEnumerator bulletTimeout() {
		yield return new WaitForSeconds(bulletTimeoutTime);
		Destroy(gameObject);
	}
	
}
