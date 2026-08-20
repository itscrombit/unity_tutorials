using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Item/Create New Item")]
public class ItemsInv : ScriptableObject
{
    public string itemName; // Defining Values needed for every item you want to show in Inventory
    public int id;
    public int value;
    public Sprite icon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
