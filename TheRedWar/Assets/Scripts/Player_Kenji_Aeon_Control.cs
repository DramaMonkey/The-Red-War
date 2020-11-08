using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Kenji_Aeon_Control : MonoBehaviour
{
	public GameObject FollowPoint;
	public SpriteRenderer spriteRend;
	private Vector3 GoTo;
	
	void Update(){
		GoTo = new Vector3(FollowPoint.transform.position.x, FollowPoint.transform.position.y, 0);
		
		if(FollowPoint.transform.position.x > transform.position.x){
			spriteRend.flipX = false;
		} else if(FollowPoint.transform.position.x < transform.position.x) {
			spriteRend.flipX = true;
		}
		
		transform.position = Vector3.MoveTowards(transform.position, GoTo, 0.03f);
	}
	
	public void attack(GameObject target){
		print("aeon attack target : " +target );
	}
}
