using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class LampScript : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerClickHandler
{

    /// <summary>
    /// Same Script for all Inventroy item Scripts like ChestKeyScript,BatteryScript, Etc. But The Benefit is that you can add more features and Function for each individual
    /// like if you are making a key using for for a chest or writing function for a Flashlight or something else.
    /// </summary>

    public static ItemsInv Item;

    private bool isSelected;

    public static int dropONOFF = 0;

    public void OnSelect(BaseEventData eventData) //On click of Item Prefab Button Remember to add ISelectHandler
    {
        // Set Showcase Image back to full opacity
        Image showcaseImg = GameObject.Find("ShowcaseImage").GetComponent<Image>();
        Color spriteColor = showcaseImg.color;
        spriteColor.a = 1.0f; // Set the desired alpha value (0.0f - fully transparent, 1.0f - fully opaque)
        showcaseImg.color = spriteColor;

        // Executing Showcase Method
        TextMeshProUGUI showcaseTxt = GameObject.Find("ShowcaseText").GetComponent<TextMeshProUGUI>();
        UpdateShowcaseImage(showcaseImg, showcaseTxt);

        isSelected = true;
        Debug.Log("Button is selected.");

    }

    public void OnDeselect(BaseEventData eventData) //On click Something else than the Item Prefab Button Remember to add IDeselectHandler
    {
        AlphaZero();
        isSelected = false;
        Debug.Log("Button is deselected.");
    }


    // Start is called before the first frame update
    void Start()
    {

        AlphaZero();

    }

    public void AlphaZero() //Making Method to make showcase image & Text Null, Easy to call
    {
        // Set Showcase Text to null
        TextMeshProUGUI showcaseTxt = GameObject.Find("ShowcaseText").GetComponent<TextMeshProUGUI>();
        showcaseTxt.text = null;


        // Set Showcase Image back to 0 opacity
        Image showcaseImg = GameObject.Find("ShowcaseImage").GetComponent<Image>();
        Color spriteColor = showcaseImg.color;
        spriteColor.a = 0.0f; // Set the desired alpha value (0.0f - fully transparent, 1.0f - fully opaque)
        showcaseImg.color = spriteColor;
    }

    public void OnPointerClick(PointerEventData eventData) //To get deleted on Selection if Drop Button is Cliked or Red
    {
        if (dropONOFF == 1)
        {
            Debug.Log(Item + "*Deleted*");

            // Removing Item from the list
            InventoryManager.Instance.Remove(Item); //Sending instruction to Inventory Manager to delete this specific item from the list
            Destroy(gameObject); // Destorying GameObject or Visible Item Prefab Button in Inventory UI
            AlphaZero();
        }
        else
        {
            Debug.Log("Drop Button Not Selected");
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (isSelected == true && Input.GetButtonDown("Delete")) //To Check and Delete the item on selecting item and then pressing delete button from the Keyboard, Also need to set Delete Button From Input Manager
        {
            Debug.Log(Item + "*Deleted*");

            // Removing Item from the list
            InventoryManager.Instance.Remove(Item);
            Destroy(gameObject);
            AlphaZero();
        }
    }

    private void UpdateShowcaseImage(Image showcaseImg, TextMeshProUGUI showcaseTxt)
    {
        showcaseImg.sprite = Item.icon;
        showcaseTxt.text = Item.itemName;
    }

}
