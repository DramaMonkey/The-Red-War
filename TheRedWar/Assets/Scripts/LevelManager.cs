using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LevelManager : MonoBehaviour {
	public static LevelManager instance;
	
	public Transform respawnPoint;
	public GameObject playerPrefab;
	
	public CinemachineVirtualCameraBase cam;
		
		
	[Header("Currency")]
	public int currency = 0;
	public Text currencyUI;
	

	private void Awake() {
		instance = this;
	}
	
	public IEnumerator Respawn() {
		yield return new WaitForSeconds(2f);
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	

	public void FinishLevel () {
		SceneManager.LoadScene("MainMenu");
	}

	
	public void IncreaseCurrency(int amount) {
		currency += amount;
		currencyUI.text = "£" + currency;
	}
	
	
}
