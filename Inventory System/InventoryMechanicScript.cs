using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMechanicScript : MonoBehaviour
{
    public GameObject inventory;
    public GameObject Hud;
    public GameObject invBg;

    public Behaviour player;

    public Button closeButton;


    public bool isInvOpen;

    // Start is called before the first frame update
    void Start()
    {

        Button closebtn = closeButton.GetComponent<Button>();
        closebtn.onClick.AddListener(TaskOnClick);
        inventory.SetActive(false);
        invBg.SetActive(false);
        isInvOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) //To Toggle Open Inventory on Pressing I Button
        {
            ToggleInventory();
        }

        if (isInvOpen == true && Input.GetButtonDown("Escape")) //To Close Inventory on Pressing escape Button on Keyborad which has to be set in Edit>ProjectSettings>InputManager then copy a button above and name should be specific "Escape" and on positive button "escape"
        {
            player.GetComponent<FirstPersonController>().enabled = true;
            inventory.SetActive(false);
            Hud.SetActive(true);
            isInvOpen = false;
            invBg.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }

    void TaskOnClick() //On UI Inventory close or x button clicked with mouse //Same to Close the Inventory
    {
        Debug.Log("You have clicked the button!");
        player.GetComponent<FirstPersonController>().enabled = true;
        inventory.SetActive(false);
        Hud.SetActive(true);
        isInvOpen = false;
        invBg.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    private void ToggleInventory()
    {
        isInvOpen = !isInvOpen; // Toggle the inventory state

        inventory.SetActive(isInvOpen); // Set the inventory UI game object active or inactive based on the state

        // Enable or disable the first-person character
        player.GetComponent<FirstPersonController>().enabled = !isInvOpen;

        // Toggle cursor visibility
        Cursor.visible = isInvOpen;

        // Toggle cursor movement
        Cursor.lockState = isInvOpen ? CursorLockMode.None : CursorLockMode.Locked;

        // Toggle HUD/UI
        Hud.SetActive(!isInvOpen);

        // Toggle Background
        invBg.SetActive(isInvOpen);

        // Toggle TimeScale
        Time.timeScale = isInvOpen ? 0 : 1;

        if (isInvOpen) // Checking if inventory is open
        {
            InventoryManager.Instance.ListItems(); // ListItems method is called in Inventory Manager or Showing items when Inventory is opening, Does not mean adding items to item list

        }
    }
}
