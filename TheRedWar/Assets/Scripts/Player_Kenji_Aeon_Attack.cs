using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Kenji_Aeon_Attack : MonoBehaviour
{
	
	Vector3 mousePos;
	public GameObject aeon_Scan;
	private GameObject currentScan;
	
	
	private void Update() {
		if(Input.GetMouseButtonDown(1)){

			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			
			currentScan = Instantiate(aeon_Scan, mousePos, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
			//Destroy(currentScan);
			//print(FindClosestEnemy(mousePos));






		}
	}
	
	
	
	
	
	
	
	
	/*
	public GameObject FindClosestEnemy(Vector3 inputPos)
    {
        GameObject[] gos;
		
        gos = GameObject.FindGameObjectsWithTag("Enemy");
		
        GameObject curGo = null;
		float curGoDistance = Mathf.Infinity;
 
        foreach (GameObject go in gos)
        {
			float compareDistance = Vector3.Distance(go.transform.position, inputPos);
			
			if (compareDistance < curGoDistance)
            {
                curGo = go;
                curGoDistance = compareDistance;
            }
			
        }
        return curGo;
    }
	*/
}
