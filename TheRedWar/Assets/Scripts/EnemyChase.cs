using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour {
	
	public float speed = 6f;
	public float jumpHieght = 2f;
	public float sightRange = 10f;
	public float chaseTime = 5;
	public float patrolRange = 3;
	public float damageToPlayer = 2;
	
	public Rigidbody2D rb;
	public LayerMask playerLayers;
	public LayerMask groundLayers;
	
	public Transform LeftEye;
	public Transform RightEye;
	public Transform feet;
	
	public Vector2 direction;
	
	public Animator anim;
	public SpriteRenderer spriteRend;
	
	string setDirection = "none"; //"none" "right" or "left"
	string patrolDirection = "right";
	bool jump = false;
	bool chaseActive = false;
	float stopChaseTime;
	float patrolTime;
	
	
	RaycastHit2D playerCheckRight;
	RaycastHit2D playerCheckLeft;
	
	RaycastHit2D wallCheckRight;
	RaycastHit2D wallCheckLeft;
	
	
	private void Start(){
		patrolTime = Time.time;
	}
	
	private void Update(){
		
		//If moving left, look left, else if looking right, look right
		if(setDirection == "right"){ 
			//transform.localScale = new Vector3(1f,1f,1f);
			spriteRend.flipX = false;
		} else if(setDirection == "left"){
			//transform.localScale = new Vector3(-1f,1f,1f);
			spriteRend.flipX = true;
		}
		
		anim.SetBool("isChasing", chaseActive);
		
		// Look for player
		playerCheckRight = Physics2D.Raycast(RightEye.position, transform.right, sightRange, playerLayers);
		playerCheckLeft = Physics2D.Raycast(LeftEye.position, -transform.right, sightRange, playerLayers);
		
		if(playerCheckLeft.collider != null){
		   if (playerCheckLeft.collider.tag == "Player") {
				setDirection = "left";
				stopChaseTime = Time.time + chaseTime;
				chaseActive = true;
           }
		}
		
		if(playerCheckRight.collider != null){
		   if (playerCheckRight.collider.tag == "Player") {
                setDirection = "right";
				stopChaseTime = Time.time + chaseTime;
				chaseActive = true;
           }
		}
		
		
		// If I hit a wall, jump
		wallCheckRight = Physics2D.Raycast(RightEye.position, transform.right, 0.3f, groundLayers);
		wallCheckLeft = Physics2D.Raycast(LeftEye.position, -transform.right, 0.3f, groundLayers);
		
		jump = false;
		
		if(wallCheckLeft.collider != null && setDirection == "left"){
			jump = true;
		}
		
		if(wallCheckRight.collider != null && setDirection == "right"){
			jump = true;
		}
		
		// Stop chasing player timeout
		if(stopChaseTime < Time.time){
			setDirection = "none";
			chaseActive = false;
		}
		
		// If I'm not chasing, and I can't find a player, patrol around

		if(patrolTime < Time.time){
			patrolTime = Time.time + patrolRange;
			if(chaseActive == false){
				switch (patrolDirection)
				{
					case "right":
						patrolDirection = "left";
						break;	
					case "left":
						patrolDirection = "right";
						break;	
				}
			}
		}
		
		if(!chaseActive){
			setDirection = patrolDirection;
		}
		
	}
	
	private void FixedUpdate(){		
		// Handle Movement
		//print(setDirection);
		switch (setDirection)
		{
			case "left":
				rb.velocity = new Vector2(-speed, rb.velocity.y);
				break;	
			case  "right":
				rb.velocity = new Vector2(speed, rb.velocity.y);
				break;
			case  "none":
				rb.velocity = new Vector2(0, 0);
				break;
		}
		
		if(jump && IsGrounded()){
			rb.velocity = new Vector2(rb.velocity.x, jumpHieght);
		}
	
	}
	
	
	public bool IsGrounded(){
		Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.3f, groundLayers);
		
		if(groundCheck != null){
			return true;	
		}
		
		return false; 
	}
	
	
}
