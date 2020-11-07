using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class AtrixBossTrigger : MonoBehaviour {
	
	[HideInInspector]public GameObject atrix;
	public CinemachineVirtualCamera vcam;
	public GameObject arenaCam;
	public GameObject atrixHealthBar;
	
	public void Start(){
		atrixHealthBar = GameObject.FindGameObjectWithTag("bossHealthBar");
		atrixHealthBar.GetComponent<AtrixHealthBar>().AtrixHealthBar_SetStatus(false);
	}
	
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player")){
			atrix = GameObject.Find("Boss_Atrix");
			atrix.GetComponent<AtrixBossControl>().setFightStatus("intro");
			
			atrixHealthBar.GetComponent<AtrixHealthBar>().AtrixHealthBar_SetStatus(true);
			
			vcam.m_Follow = arenaCam.transform;
			
		}
	}
}
