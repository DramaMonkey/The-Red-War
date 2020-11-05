using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPicker : MonoBehaviour {
	public int worth = 100;
	
	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.CompareTag("Player")) {
			Destroy(gameObject);
			LevelManager.instance.IncreaseCurrency(worth);
		}
	}
    
}
