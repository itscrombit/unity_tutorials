using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBarScript : MonoBehaviour
{
    public Slider foodSlider;       // Reference to the UI slider
    public float maxFood = 100f;    // Maximum amount of food
    public float foodDrainRate = 0.1f; // Food drain per second

    private float currentFood;

    public Slider waterSlider;       
    public float maxWater = 100f;    
    public float waterDrainRate = 0.1f; 

    private float currentWater;

    public Slider healthSlider;       
    public float maxHealth = 100f;    
    public float healthDrainRate = 10f; 

    private float currentHealth;

    //public GameObject Spikes;
    public bool inReach;


    void Start()
    {
        // Initialize the slider and food amount
        //Food
        currentFood = maxFood;
        foodSlider.maxValue = maxFood;
        foodSlider.value = currentFood;

        //Water
        currentWater = maxWater;
        waterSlider.maxValue = maxWater;
        waterSlider.value = currentWater;

        //Health
        inReach = false;
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach2")
        {
            inReach = true;
            Debug.Log("true");

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach2")
        {
            inReach = false;
            Debug.Log("false");

        }
    }

    void Update()
    {
        // Drain food over time
        DrainFood(Time.deltaTime);
        DrainWater(Time.deltaTime);
        DrainHealth(Time.deltaTime);
    }

    void DrainFood(float deltaTime)
    {
        // Decrease current food based on the drain rate and time
        currentFood -= foodDrainRate * deltaTime;

        // Ensure current food doesn't go below zero
        currentFood = Mathf.Clamp(currentFood, 0, maxFood);

        // Update the slider UI
        foodSlider.value = currentFood;

        // You can add logic here for what happens when food reaches zero
        if (currentFood <= 0)
        {
            // Handle food depletion (e.g., player dies or needs to refill food)
            Debug.Log("Food is depleted!");
        }
    }
    void DrainWater(float deltaTime)
    {
        // Decrease current water based on the drain rate and time
        currentWater -= waterDrainRate * deltaTime;

        // Ensure current water doesn't go below zero
        currentWater = Mathf.Clamp(currentWater, 0, maxWater);

        // Update the slider UI
        waterSlider.value = currentWater;

        // You can add logic here for what happens when water reaches zero
        if (currentWater <= 0)
        {
            // Handle water depletion (e.g., player dies or needs to refill water)
            Debug.Log("Water is depleted!");
        }
    }
    

    void DrainHealth(float deltaTime)
    {
        // Decrease current health based on the drain rate and time
        if (inReach == true)
        {
            currentHealth -= healthDrainRate * deltaTime;
            Debug.Log("draining");
        }
        else
        {

        }

        // Ensure current health doesn't go below zero
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Update the slider UI
        healthSlider.value = currentHealth;

        // You can add logic here for what happens when health reaches zero
        if (currentHealth <= 0)
        {
            // Handle health depletion (e.g., player dies or needs to refill health)
            Debug.Log("Health is depleted!");
        }
    }
}
