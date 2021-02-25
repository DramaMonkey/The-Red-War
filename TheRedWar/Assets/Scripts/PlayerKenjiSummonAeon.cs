using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKenjiSummonAeon : MonoBehaviour {
	public GameObject Aeon_Spawn;
	public GameObject Player_Kenji_Aeon;
	
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Player_Kenji_Aeon, Aeon_Spawn.transform.position, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
    }

}
