using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Kenji_Aeon_Control : MonoBehaviour
{
	public GameObject PlayerFollowPoint;
	private GameObject FollowPoint;
	private GameObject newGoTo;
	public float followSpeed;
	public SpriteRenderer spriteRend;
	private Vector3 GoTo;
	private bool attacking = false;
	
	void Start(){
		PlayerFollowPoint = GameObject.Find("AeonPos");
		setGoToTarget(PlayerFollowPoint);
	}
	
	void Update(){
		GoTo = new Vector3(FollowPoint.transform.position.x, FollowPoint.transform.position.y, 0);
		
		if(FollowPoint.transform.position.x > transform.position.x){
			spriteRend.flipX = false;
		} else if(FollowPoint.transform.position.x < transform.position.x) {
			spriteRend.flipX = true;
		}
		
		transform.position = Vector3.MoveTowards(transform.position, GoTo, followSpeed);
	}
	
	public void attack(GameObject target){
		setGoToTarget(target);
		attacking = true;
		StartCoroutine("returnToPlayerTimeout");
	}
		
	private void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag == "Enemy" && attacking == true){
			collision.gameObject.GetComponent<EnemyHealth>().AddjustCurrentHealth(-1);
			attacking = false;
			setGoToTarget(PlayerFollowPoint);
		}
	}
	
	
	
	
	public void setGoToTarget(GameObject newGoToTarget){
		FollowPoint = newGoToTarget;
	}
	
	IEnumerator returnToPlayerTimeout(){	
		yield return new WaitForSeconds(2f);
		setGoToTarget(PlayerFollowPoint);
		attacking = false;
	}
	
}
