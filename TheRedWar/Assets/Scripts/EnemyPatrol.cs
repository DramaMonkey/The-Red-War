using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {
	public float speed = 2f;
	public Rigidbody2D rb;
	public LayerMask groundLayers;
	
	public Transform groundCheck;
	public Transform wallCheck;
	
	public Vector2 direction;
	
	bool isFacingRight = true;
	bool swapDirection = false;
	
	RaycastHit2D swapCheck;
	
	private void Update(){
		// Check if falling off a ledge
		swapCheck = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);
		
		if(swapCheck.collider == null){
			swapDirection = true;
		}
		
		
		//Check if bumped into a wall
		if(isFacingRight){
			direction = transform.right;
		} else {
			direction = -transform.right;
		}
			
		swapCheck = Physics2D.Raycast(wallCheck.position, direction,0.1f, groundLayers);
		
		if(swapCheck.collider != null){
			swapDirection = true;
		}
		
		
	}
	 
	private void FixedUpdate(){		
		if (swapDirection == false){
			// if is facing right, move right, else move left
			if(isFacingRight){
				rb.velocity = new Vector2(speed, rb.velocity.y);
			} else {
				rb.velocity = new Vector2(-speed, rb.velocity.y);
			}
		} else {
			// swap direction
			isFacingRight = !isFacingRight;
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1f);
			swapDirection = false;
		}
	}
}
