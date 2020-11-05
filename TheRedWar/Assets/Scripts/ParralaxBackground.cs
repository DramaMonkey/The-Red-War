using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxBackground : MonoBehaviour {
 
	[SerializeField] private Vector2 parallaxEffectMultiplier = new Vector2(0.3f, 0.3f);
	private Transform cameraTransform;
	private Vector3 lastCameraPosition;
	private float textureUnitSizeX;
	
	private void Start() {
		cameraTransform = Camera.main.transform;
		lastCameraPosition = cameraTransform.position;
		
		Sprite sprite = GetComponent<SpriteRenderer>().sprite;
		Texture2D texture = sprite.texture;
		textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
	}
	
	private void FixedUpdate() {
		Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
		
		transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
		
		lastCameraPosition = cameraTransform.position;
		
		if(Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX) {
		float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
			transform.position = new Vector3 (cameraTransform.position.x + offsetPositionX, transform.position.y);
		}
		
	}
 
}
