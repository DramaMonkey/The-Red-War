using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStab : MonoBehaviour { 
	public float fireRate = 1f;
	public float bulletDamage = 1f;
	// Transform is a position/rotation/scale data type. 
	public Transform firingPoint;
	public GameObject swordPrefab;
	public GameObject sword;
	
	float timeUntilFire;
	float angle;
	bool flip;
	PlayerMovement pm;
	
	private void Start() {
		pm = gameObject.GetComponent<PlayerMovement>();
	}
	
	private void Update() {
		if(Input.GetMouseButtonDown(0) && timeUntilFire < Time.time){
			Stab();
			timeUntilFire = Time.time + fireRate;
		}
	}
	

	
	void Stab(){
		if(pm.isFacingRight == true){
			angle = 0f;
			flip = false;
		} else if (pm.isFacingRight == false) {
			angle = 180f;
			flip = true;
		}
		
		// create this and this position with this angle - using gameObjects to input pos and angle
		
		
		sword = Instantiate(swordPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
		StartCoroutine(swordMotion(sword));
		

	}
	
	IEnumerator swordMotion(GameObject sword){	
		sword.transform.eulerAngles = new Vector3(
			sword.transform.eulerAngles.x,
			sword.transform.eulerAngles.y,
			angle
		);
		
		//sword.transform.parent = gameObject.transform;
		
		sword.GetComponent<SpriteRenderer>().flipY = flip;
		yield return new WaitForSeconds(0.25f);
		sword.GetComponent<Bullet>().bulletSpeed = -sword.GetComponent<Bullet>().bulletSpeed;
	}
	
}
