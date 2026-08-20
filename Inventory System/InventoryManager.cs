using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<ItemsInv> items = new List<ItemsInv>(); //List

    public Transform ItemContent;
    public GameObject InventoryItem;


    private void Awake()
    {
        Instance = this;

        // Set Showcase Text to null at opening Inventory at Start When there is no item
        TextMeshProUGUI showcaseTxt = GameObject.Find("ShowcaseText").GetComponent<TextMeshProUGUI>();
        showcaseTxt.text = null;

        // Set Showcase Image back to 0 opacity at opening Inventory at Start When there is no item
        Image showcaseImg = GameObject.Find("ShowcaseImage").GetComponent<Image>();
        Color spriteColor = showcaseImg.color;
        spriteColor.a = 0.0f; // Set the desired alpha value (0.0f - fully transparent, 1.0f - fully opaque)
        showcaseImg.color = spriteColor;
    }
    public void Add(ItemsInv item) //Items in the list are added from ExaminePickupScript
    {
        items.Add(item);
    }

    public void Remove (ItemsInv itemtodelete) //Called from Item Scripts like LampScript, BatteryScript
    {
        items.Remove(itemtodelete);//Removes item from list so they don't spawn again on inventory reopen
        Debug.Log(items.Count);
    }

    public void ListItems()
    {

        //clean content
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject); //Prevents Multiple Items to be Created on Each inventory openS
        }

        foreach (var item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent); //Instantiating Item Prefab Button
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>(); //finding text name of item prefab which will be created after picking up item
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>(); //finding image of item prefab 

            itemName.text = item.itemName; // Setting text to imported item name
            itemIcon.sprite = item.icon; // Setting Sprite to imported item image

            if (item.id == 3) //Finding ID or To check that Script is attached to the right Item id
            {
                obj.AddComponent<LampScript>(); //Adding specific item script on specific item id
                ItemsInv itemWithID3 = items.Find(i => i.id == 3); //Setting Variable itemWithID3 with the right item of right id i.e. 3
                LampScript.Item = itemWithID3; //Setting ITEM IN LAMPSCRIPT 
            }
            if (item.id == 2)
            {
                obj.AddComponent<BatteryScript>();
                ItemsInv itemWithID2 = items.Find(i => i.id == 2);
                BatteryScript.Item = itemWithID2;
            }
            if (item.id == 1)
            {
                obj.AddComponent<ChestKeyScript>();
                ItemsInv itemWithID1 = items.Find(i => i.id == 1);
                ChestKeyScript.Item = itemWithID1;
            }

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
