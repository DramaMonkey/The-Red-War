using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	private Text myText;
	public string NotHovering;
	public string Hovering;
				

	void Start (){
		myText = GetComponentInChildren<Text>();
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		myText.text = Hovering;
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		myText.text = NotHovering;
	}
}