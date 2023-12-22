using HSVPicker;
using UnityEngine;
using UnityEngine.UI;

public class TogglePickupColor : MonoBehaviour
{
	public RightClickButton objectA;
	public Image objectB;
	public ColorPicker picker;
	
    void Start()
    {
	    objectA.OnRightClick += () => picker.gameObject.SetActive(!picker.gameObject.activeSelf);
	    
		picker.onValueChanged.AddListener(c =>
		{
			objectB.color = c;
		});
		
		picker.gameObject.SetActive(false);
		objectB.color = picker.CurrentColor;
    }
}
