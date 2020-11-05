using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour{
	public float maxHealth = 2f;
	public float curHealth = 2f;
	
	/*private void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.CompareTag("Bullet")){
			Destroy(gameObject);
		}
	}*/
	
	public void AddjustCurrentHealth(int adj)
	{
		curHealth += adj;

		if (curHealth < 0) {
			curHealth = 0;
		}
		
		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}
		
		if (maxHealth < 1) {
			maxHealth = 1;
		}

		if (curHealth <= 0) {
			Destroy(this);
		}
	}
	
	
	
}
