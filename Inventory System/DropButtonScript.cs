using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropButtonScript : MonoBehaviour, IPointerClickHandler
{
    private bool isSelected = false;
    private Image buttonImage;

    private Color selectedColor; // Add this variable to store the selected color.

    int ONOFF;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        selectedColor = HexToColor("#FF5353"); // Set the selected color here using the hex code.
    }


    public void OnPointerClick(PointerEventData eventData) // Click on Drop Button via Mouse to use this make sure you have ^^ , IPointerClickHandler next to MonoBehaviour
    {
        GameObject itemPrefab = GameObject.FindWithTag("InventoryItem");
        if (itemPrefab != null)
        {
            isSelected = !isSelected; // Toggle status of drop button
        }
    }

    public void Update()
    {
        if (isSelected)
        {
            // Set the selected state appearance (e.g., change the button color).
            // You can also add a highlight effect or any other visual change.
            buttonImage.color = selectedColor;
            ONOFF = 1; //Taking one as on status of dropButton
        }

        else
        {
            // Set the normal state appearance (e.g., revert the button color to its original).
            buttonImage.color = Color.white;
            ONOFF = 0; //Taking zero as off status of dropButton
        }

        
        GameObject itemPrefab = GameObject.FindWithTag("InventoryItem"); // DEFINING TAGs TO FIND PREFAB ITEMS
        if (itemPrefab != null) //Checking if there is an item or not else it will show error
        {
            LampScript.dropONOFF = ONOFF; //Sending ONOFF Status to all Items Scripts 
            ChestKeyScript.dropONOFF = ONOFF;
            BatteryScript.dropONOFF = ONOFF;

        }
        else if (itemPrefab == null)
        {
            buttonImage.color = Color.white;
            ONOFF = 0;
            isSelected = false;
            //Debug.Log("No Items to Delete");
        }
    }

    private Color HexToColor(string hex) //Setting Hex Color
    {
        Color color = new Color();
        ColorUtility.TryParseHtmlString(hex, out color);
        return color;
    }
}
