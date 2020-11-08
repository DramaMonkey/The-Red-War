using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtrixBossControl : MonoBehaviour {
	
	private GameObject player; 
	private string player_Direction; 
	
	public AtrixHealthBar healthBar;
	
	public GameObject Atrix_Attack_Spike;
	public Transform Spike_Cast;	
	
	public GameObject Atrix_Attack_Nova;
	public Transform Nova_Cast;
	
	public GameObject EndFlag;
	public Transform EndFlagPos;
	
	public string fightSection = "false";
	public float maxHealth;
	public float curHealth;
	public float speed;
	
	public Rigidbody2D rb;
	public BoxCollider2D bc;
	private SpriteRenderer spriteRenderer; 
	
	public Transform AtrixStartPoint;
	public Sprite Atrix_Channel_1;
	public Sprite Atrix_Channel_2;
	public Sprite Atrix_Dead_1;
	public Sprite Atrix_Frenzy_1;
	public Sprite Atrix_Idle_1;
	public Sprite Atrix_Idle_2;
	public Sprite Atrix_Nova_1;
	public Sprite Atrix_Spike_1;
	public Sprite Atrix_Spike_2;
	public Sprite Atrix_Transition_1;
	public Sprite Atrix_Wait_1;
	
	
	public float attackCooldown_Max = 8;
	public float attackCooldown_Min = 3f;
	public float attackChoice = -1f;
	
	private float attackCooldown_NextAttack = 0f;
	
	public float attackCooldown_SpikeDelay = 1f;
	private float attackCooldown_SpikeNextAttack = 0f;
	
	public float attack_fenzySpeedMult = 3f;
	
	private bool atrix_Attacking = false;
	
	private string activeCoroutine = "";

	// Setup objects at start
	void Start(){

		player = GameObject.FindGameObjectWithTag("Player");
		spriteRenderer = GetComponent<SpriteRenderer>();
		
	}
	
	// Every game tick, do stuff
	private void Update(){
		// hp check every frame
		if(curHealth <= 0){
			atrix_Death();
		}
		

		// run intro on fight start
		if(fightSection == "intro"){
			StartCoroutine("atrix_Intro");
			fightSection = "intro_Running";
			
			set_attackCooldown_NextAttack();
		}
		
		// if fighting
		if(fightSection == "fight"){
			// update hp bar every frame
			curHealth = GetComponent<EnemyHealth>().curHealth;
			healthBar.SetHealth( curHealth );
			
			
			// Chase the player, if they are in range, do a spike attack.
				// spike if player within L/R of 1.5 units and within height of 2 units
				
				
				
			if(player.transform.position.x > this.transform.position.x){	
				player_Direction = "right";
			} else if(player.transform.position.x < this.transform.position.x){
				player_Direction = "left";
			}
			if(atrix_Attacking == false) {
				float scanDistance_Side = 6f;
				float scanDistance_Height = 10f;
				if(attackCooldown_SpikeNextAttack < Time.time && player.transform.position.x > this.transform.position.x - scanDistance_Side && player.transform.position.x < this.transform.position.x + scanDistance_Side &&  player.transform.position.y <this.transform.position.y + scanDistance_Height){
					atrix_SpikeAttack();
				} 
				
				// Chase player - move left or right to follow them
				if(player_Direction == "right"){
					rb.velocity = new Vector2(speed, rb.velocity.y);
				} else if(player_Direction == "left"){
					rb.velocity = new Vector2(-speed, rb.velocity.y);
				}
				
				// Check time for attack, then pick a random attack
				if(attackCooldown_NextAttack < Time.time){
					
					rb.velocity = new Vector2(0, rb.velocity.y);
					atrix_Attacking = true;
					attackChoice = Random.Range(0,5);
					//attackChoice = 0;//debug
					
					if(attackChoice >= 0 && attackChoice <= 1){
						StartCoroutine("atrix_Frenzy");
					} else if (attackChoice >= 2 && attackChoice <= 5) { 
						StartCoroutine("atrix_Nova");
					}
					
					
				}
			}

		}
		
		//Stops Atrix escaping the arena in frenzy
		if(activeCoroutine == "atrix_Frenzy" && (this.transform.position.x < 144.6301 | this.transform.position.x >164.7977)){
			rb.velocity = new Vector2(0, rb.velocity.y);
		}
		
	}
	
/* ----- INTRO ----- */
	// intro anims
	IEnumerator atrix_Intro() {
		//intro animation etc. done here
		this.transform.position = AtrixStartPoint.position;		
		yield return new WaitForSeconds(0.8f);
		
		spriteRenderer.sprite = Atrix_Transition_1;
		this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 1f);
		yield return new WaitForSeconds(0.8f);
		
		spriteRenderer.sprite = Atrix_Idle_1;
		this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 2f);
		fightSection = "fight";
	}
	
/* ----- ATTACKS ----- */
	// Spike attack to be run during idle time
	private void atrix_SpikeAttack(){
		Instantiate(Atrix_Attack_Spike, Spike_Cast.transform.position , Quaternion.Euler(new Vector3(0f, 0f, 0f)));
		attackCooldown_SpikeNextAttack = Time.time + attackCooldown_SpikeDelay;
	}
	
	// Frenzy attack - rises, runs at the player a few times, then lowers
	IEnumerator atrix_Frenzy(){	
		activeCoroutine = "atrix_Frenzy";
		//Rise out of the ground
		this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 2f);
		spriteRenderer.sprite = Atrix_Transition_1;
		yield return new WaitForSeconds(0.8f);
		
		this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1f);
		spriteRenderer.sprite = Atrix_Frenzy_1;
		
		rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation ;
		
		//attack 2-4 times @ player
		rb.gravityScale = 1.0f;
		yield return new WaitForSeconds(0.8f);
		int numOfAttacks = Random.Range(2,5);

		for (int i = 0;i < numOfAttacks;i++) {
			float frenzySpeed = 0;
			// Set direction
			if(player_Direction == "right"){
				spriteRenderer.flipX = true;
				frenzySpeed = speed*attack_fenzySpeedMult;		
			} else if(player_Direction == "left"){
				frenzySpeed = -speed*attack_fenzySpeedMult;
				spriteRenderer.flipX = false;
			}
			// Dealy between look and attack
			yield return new WaitForSeconds(0.3f);
			
			//Move at player, wait, stop
			rb.velocity = new Vector2(frenzySpeed, rb.velocity.y);	
			yield return new WaitForSeconds(0.7f);
			rb.velocity = new Vector2(0, rb.velocity.y);
			
			//Between each attack
			yield return new WaitForSeconds(1f);
			
		}

		//Lower back to idle & reset attack timer
		set_attackCooldown_NextAttack();
		rb.gravityScale = 0.0f;
		StartCoroutine("atrix_Lower");
	}
	
	// Nova - Rises, big explosion, lower
	IEnumerator atrix_Nova(){
		activeCoroutine = "atrix_Nova";
		this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 2f);
		spriteRenderer.sprite = Atrix_Transition_1;
		yield return new WaitForSeconds(0.8f);
		
		this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1f);
		spriteRenderer.sprite = Atrix_Channel_1;
		yield return new WaitForSeconds(2f);
		
		spriteRenderer.sprite = Atrix_Channel_2;
		yield return new WaitForSeconds(2f);
		
		Instantiate(Atrix_Attack_Nova, Nova_Cast.transform.position , Quaternion.Euler(new Vector3(0f, 0f, 0f)));
		
		//Lower back to idle & reset attack timer
		set_attackCooldown_NextAttack();
		StartCoroutine("atrix_Lower");
	
	}
	
	
	
/* ----- Utility functions ----- */	
	// lower atrix back to idle 
	IEnumerator atrix_Lower(){	
		activeCoroutine = "atrix_Lower";	
		yield return new WaitForSeconds(0.8f);
		
		spriteRenderer.sprite = Atrix_Transition_1;
		this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 1f);
		yield return new WaitForSeconds(0.8f);
		
		spriteRenderer.sprite = Atrix_Idle_1;
		this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 2f);
		atrix_Attacking = false;
	}
	
	// sets next attack timer
	private void set_attackCooldown_NextAttack(){
		attackCooldown_NextAttack = Random.Range(attackCooldown_Min, attackCooldown_Max) + Time.time;
	}
	
	// on death
	public void atrix_Death(){
		fightSection = "dead";
		StopCoroutine(activeCoroutine);
		healthBar.SetHealth( 0 );
		this.transform.position = AtrixStartPoint.position;	
		rb.constraints = RigidbodyConstraints2D.FreezeAll;
		Destroy(rb);
		bc.enabled = false;
		spriteRenderer.sprite = Atrix_Dead_1;
		
		Instantiate(EndFlag, EndFlagPos.transform.position , Quaternion.Euler(new Vector3(0f, 0f, 0f)));
	}
	
	// lets external code setFightStatus
	public void setFightStatus(string setStatus){
		fightSection = setStatus;
	}
	
}
