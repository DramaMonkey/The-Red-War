using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour{
	public float maxHealth = 5;
	public float curHealth = 5;
	
	public float iframes = 1f;
	float iframeTimeout = 0;
	
	float damageToPlayer;
	
	public Rigidbody2D rb; 
	private HealthBar healthBar;
	
	SpriteRenderer sprite;

	private void Start(){
		healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
		sprite = GetComponent<SpriteRenderer>();
	}

	private void OnCollisionStay2D(Collision2D collision){
		if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.tag == "Spike"){
			damageToPlayer = collision.gameObject.GetComponent<EnemyDamageToPlayer>().getDamageToPlayer();
			enemyHitPlayer(damageToPlayer);
		}
	}
	
	private void OnTriggerStay2D(Collider2D collision) {
		if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.tag == "Spike"){
			damageToPlayer = collision.gameObject.GetComponent<EnemyDamageToPlayer>().getDamageToPlayer();
			enemyHitPlayer(damageToPlayer);
		}
	}
	
	private void Update(){
		if(iframeTimeout<Time.time){
			StopCoroutine("iframe_Flash");
			sprite.color = new Color (255, 255, 255, 255); 
		}
		
		if(Input.GetKeyDown(KeyCode.K)){
			this.GetComponent<PlayerMovement>().SetPlayerFreeze(true);
				
			StartCoroutine(LevelManager.instance.Respawn());
			StartCoroutine(playerDeath());
		}
			
	}
	
	
	void enemyHitPlayer(float damageDealt){
			//iframe check
			if(iframeTimeout<Time.time){
				//When take damage...
				
				
				curHealth -= damageDealt;
				
				healthBar.SetHealth( curHealth );
				
				StartCoroutine("iframe_Flash");
				iframeTimeout = Time.time+iframes;
			}
						
			//death check
			if(curHealth <= 0){
				this.GetComponent<PlayerMovement>().SetPlayerFreeze(true);
				
				StartCoroutine(LevelManager.instance.Respawn());
				StartCoroutine(playerDeath());
			}
		
	}
	
	
	IEnumerator iframe_Flash(){
		while(true){
			yield return new WaitForSeconds(0.1f);
			sprite.color = new Color (1, 0, 0, 1); 
			yield return new WaitForSeconds(0.1f);
			sprite.color = new Color (255, 255, 255, 255); 
		}
	}
	
	IEnumerator playerDeath()
	{
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}
	


}
