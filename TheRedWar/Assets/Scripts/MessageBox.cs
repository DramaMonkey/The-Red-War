using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour {
	public string messageBoxText;
	public GameObject textBoxPrefab;
	public GameObject Canvas;
	private GameObject newText;
	private Text textBoxGameObject;
	
	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.CompareTag("Player")) {
			newText = Instantiate(textBoxPrefab, new Vector2(0, 0), Quaternion.identity);
			
			newText.transform.SetParent(Canvas.transform);
			newText.transform.localScale = new Vector3(1,1,1);
			newText.transform.localPosition = new Vector3(0, -350, 0);
			textBoxGameObject = newText.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
			textBoxGameObject.text = messageBoxText;
		}
	}
	
	private void OnTriggerExit2D(Collider2D collision) {
		if(collision.CompareTag("Player")) {
			Destroy(newText);
		}
	}
}
