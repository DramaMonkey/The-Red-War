using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackControl : MonoBehaviour {
	public float player_GlobalAttackCooldown;
	
	public void set_player_GlobalAttackCooldown(float newCooldown){
		player_GlobalAttackCooldown = newCooldown;
	}
	
	public float get_player_GlobalAttackCooldown(){
		return player_GlobalAttackCooldown;
	}
}
