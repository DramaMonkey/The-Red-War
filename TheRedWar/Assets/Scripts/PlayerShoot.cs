
using UnityEngine;

public class PlayerShoot : MonoBehaviour { 
	public float fireRate = 0.2f;
	// Transform is a position/rotation/scale data type. 
	public Transform firingPoint;
	public GameObject bulletPrefab;
	
	float timeUntilFire;
	PlayerMovement pm;
	
	private void Start() {
		pm = gameObject.GetComponent<PlayerMovement>();
	}
	
	private void Update() {
		if(Input.GetMouseButtonDown(0) && timeUntilFire < Time.time){
			Shoot();
			timeUntilFire = Time.time + fireRate;
		}
	}
	
	
	
	
	
	
	void Shoot(){
		// ? is a if true operator (if true then 0f else 180f)
		float angle = pm.isFacingRight ? 0f : 180f;
		
		// create this and this position with this angle - using gameObjects to input pos and angle
		
		Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
	}
	
}
