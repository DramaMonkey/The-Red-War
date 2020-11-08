using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class AtrixBossTrigger : MonoBehaviour {
	
	[HideInInspector]public GameObject atrix;
	public CinemachineVirtualCamera vcam;
	public GameObject arenaCam;
	public GameObject atrixHealthBar;
	public GameObject AtrixArenaDoor;
	
	public void Start(){
		atrixHealthBar = GameObject.FindGameObjectWithTag("bossHealthBar");
		AtrixArenaDoor = GameObject.Find("AtrixArenaDoor");
		atrixHealthBar.GetComponent<AtrixHealthBar>().AtrixHealthBar_SetStatus(false);
		AtrixArenaDoor.SetActive(false);
	}
	
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player")){
			AtrixArenaDoor.SetActive(true);
			atrix = GameObject.Find("Boss_Atrix");
			atrix.GetComponent<AtrixBossControl>().setFightStatus("intro");
			
			atrixHealthBar.GetComponent<AtrixHealthBar>().AtrixHealthBar_SetStatus(true);
			
			vcam.m_Follow = arenaCam.transform;
			vcam.m_Lens.OrthographicSize = 7;
			
		}
	}
}
