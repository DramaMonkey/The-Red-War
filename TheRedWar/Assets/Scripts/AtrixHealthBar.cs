using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtrixHealthBar : MonoBehaviour
{
    public Slider healthBar;
    public EnemyHealth atrixHealthValue;

    private void Start()
    {
        atrixHealthValue = GameObject.Find("Boss_Atrix").GetComponent<EnemyHealth>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = atrixHealthValue.maxHealth;
        healthBar.value = atrixHealthValue.maxHealth;
		//gameObject.SetActive(false);
    }

	public void AtrixHealthBar_SetStatus(bool setStatus){
		gameObject.SetActive(setStatus);
	}
	
	public void SetHealth(float hp)
    {
        healthBar.value = hp;
    }
}