using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour{
	public float maxHealth = 2f;
	public float curHealth = 2f;
	SpriteRenderer sprite;
	
	/*private void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.CompareTag("Bullet")){
			Destroy(gameObject);
		}
	}*/
	
	
	private void Start(){
		 sprite = GetComponent<SpriteRenderer>();
	}
	
	public void AddjustCurrentHealth(float adj)
	{

		curHealth += adj;
		
		if (adj < 0 && curHealth >= 1){
			StartCoroutine("damageFlashControler");
		}
		
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
			enemyDeath(this.gameObject.transform.name);			
		}
	}
	
	
	public void enemyDeath(string enemyName){
		// Handle custom deaths manually... otherwise just pop the gameObject
		switch (enemyName){
			case "Boss_Atrix":
				GameObject.Find("Boss_Atrix").GetComponent<AtrixBossControl>().atrix_Death();
				//Destroy(this.gameObject);
				break;
				
			default:
				Destroy(this.gameObject);
				break;
        }
		

	}
	
	IEnumerator damageFlashControler(){
		StartCoroutine("damage_Flash");
		yield return new WaitForSeconds(0.5f);
		StopCoroutine("damage_Flash");
		sprite.color = new Color (255, 255, 255, 255);
	}
	
	IEnumerator damage_Flash(){
		while(true){
			yield return new WaitForSeconds(0.1f);
			sprite.color = new Color (1, 0, 0, 1); 
			yield return new WaitForSeconds(0.1f);
			sprite.color = new Color (255, 255, 255, 255); 
		}
	}
	
	
}
