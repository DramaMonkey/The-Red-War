using UnityEngine;

public class Bullet : MonoBehaviour {
	public float bulletSpeed = 15f;
	public float bulletDamage = 1f;
	public Rigidbody2D rb;
	
	private void FixedUpdate(){
		rb.velocity = transform.right * bulletSpeed;
	}
	
	private void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag != "Player"){
			Destroy(gameObject);
		}
		if(collision.gameObject.tag == "Enemy"){
			collision.gameObject.GetComponent<EnemyHealth>().curHealth -= bulletDamage;
			
			if(collision.gameObject.GetComponent<EnemyHealth>().curHealth <= 0){
				Destroy(collision.gameObject);
			}
		}
	}
	
	/*void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemy" ){
			EnemyHealth eHealth = other.GameObject.GetComponent<EnemyHealth>();
			eHealth.AdjustCurrentHealth(damage);
		}
		Destroy(this.gameObject);
	}*/
	
	
	//Weapon Collider Script
	/*void OnTriggerEnter(Collider hit){
		if(hit.gameObject.tag == "Enemy"){
			//hit.getComponent<EnemyHealth>().curHealth -= bulletDamage;
			hit.GetComponent<EnemyHealth>().curHealth -= bulletDamage;
		}
	}*/
 
	
}
