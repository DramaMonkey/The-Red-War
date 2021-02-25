using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float movementSpeed;
	public Rigidbody2D rb; 
	
	public Animator anim;
	
	public float jumpForce = 20f;
	public Transform feet;
	public LayerMask groundLayers;
	
	public GameObject[] platformsArray;
	
	float movementX;
	float movementY;
	
	[HideInInspector] public bool isFacingRight = true;
	
	public bool freezePlayer ;
	
	private bool canJump;
	
	// When object spawned
	void start(){
		//pe = GetComponent<PlatformEffector2D>();
		platformsArray = GameObject.FindGameObjectsWithTag("OneWayGround");
	}
	
	// 'game tick'
	private void Update() { 
		
		if(!freezePlayer){	
			if(IsGrounded()){
				canJump = true;
			} else {
				StartCoroutine(setCantJump());
			}
				
		
		
			// -- Movement Control --
				// If a or d is pressed, set movementX to -1 or 1 respectivly
				movementX = Input.GetAxis("Horizontal");	
				movementY = Input.GetAxis("Vertical");
				
				if((Input.GetButtonDown("Jump") | movementY == 1) && canJump){
					
					// -- 1 way platforms jump -- 
					setOneWayPlatforms(0f);
					//pe.rotationalOffset = 0f; 
					Jump();
				}
			
			// -- 1 way platforms drop -- 
				
				if(movementY <= -0.15f){
					setOneWayPlatforms(180f);
					//pe.rotationalOffset = 180f;
					StartCoroutine(resetPlatformOffset());
				}
				
				
				
				
				
			// -- Animation Control -- 
				// -0.05 also returns 0.05 with absoulute.. kinda a cheat way to say 'if speed is greater than 0.05 in either direction, then walking, else not walking
				if(Mathf.Abs(movementX) > 0.05f){ 
					anim.SetBool("IsRunning", true);
				} else {
					anim.SetBool("IsRunning", false);
				}
				
				//If moving left, look left, else if looking right, look right
				if(movementX > 0f){ 
					transform.localScale = new Vector3(1f,1f,1f);
					isFacingRight = true;
				} else if(movementX < 0){
					transform.localScale = new Vector3(-1f,1f,1f);
					isFacingRight = false;
				}
				
				anim.SetBool("IsGrounded", canJump);
				
		}
	
	}
	
	// 'physics tick' 
	private void FixedUpdate() { 
		// -- Movement Control --
			//movement = -1 or 1 * movementSpeed
			if(!freezePlayer){
				rb.velocity = new Vector2(movementX * movementSpeed, rb.velocity.y);
			} else {
				rb.velocity = new Vector2(0, 0);
			}

	}
	
	void Jump() {
	// -- Movement Control --
		if(!freezePlayer){
			// -- Handle 1 way platforms -- 			
			Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
		
			rb.velocity = movement;
		}
	}
	
	public IEnumerator setCantJump(){
		//Coyote time
		yield return new WaitForSeconds(0.15f);
		canJump = false;
	}
	
	public bool IsGrounded(){
		Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.3f, groundLayers);
		
		if(groundCheck != null){
			return true;	
		}
		
		return false; 
	}
	
	public void SetPlayerFreeze(bool setFreeze){
		freezePlayer = setFreeze;
	}
	
	public IEnumerator resetPlatformOffset() {
		yield return new WaitForSeconds(0.15f);
		setOneWayPlatforms(0f);
		//pe.rotationalOffset = 0f;
	}
	
	public void setOneWayPlatforms(float setRotation){
		// Sets all one way platforms to handle drops/jumps through them
		for (int i = 0; i < GameObject.FindGameObjectsWithTag("OneWayGround").Length; i++) {
				GameObject.FindGameObjectsWithTag("OneWayGround")[i].GetComponent<PlatformEffector2D>().rotationalOffset = setRotation;
		}

	}
	
}
