using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ChestKeyScript : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerClickHandler
{

    public static ItemsInv Item;

    private bool isSelected;

    public static int dropONOFF = 0;

    public void OnSelect(BaseEventData eventData)
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

    public void OnDeselect(BaseEventData eventData)
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

    public void AlphaZero()
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


    public void OnPointerClick(PointerEventData eventData)
    {
        if (dropONOFF == 1)
        {
            Debug.Log(Item + "*Deleted*");

            // Removing Item from the list
            InventoryManager.Instance.Remove(Item);
            Destroy(gameObject);
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
        if (isSelected == true && Input.GetButtonDown("Delete"))
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
