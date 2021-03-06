using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FoodManager : MonoBehaviour
{
    public GameObject[] foodToSpawn;
    public GameObject[] cutleryModels;
    public GameObject cutleryPosition;
    public Food existingFood;

    public XRRayInteractor rayInteractor;

    private bool isSpawning = false;
    private GameObject cutleryCopy;
    private int foodIndex;
    
    public void SpawnFoodSource (int index) 
    {
        foodIndex = index;
        isSpawning = true;
        rayInteractor.keepSelectedTargetValid = false;
        DestroyFood();
        
        var foodCopy = Instantiate(foodToSpawn[index], new Vector3(
            transform.position.x, 
            transform.position.y, 
            transform.position.z),
            transform.rotation);

        // If the x-rotation of the prefab is not 0, reset the rotation to its original values
        // prevents falsly imported 3d-objects from spawning sideways
        if (foodToSpawn[index].transform.eulerAngles.x != 0 || 
            foodToSpawn[index].gameObject.CompareTag("FoodCutlery"))
        {
            foodCopy.transform.eulerAngles = foodToSpawn[index].transform.eulerAngles;

            cutleryCopy = Instantiate(cutleryModels[index], new Vector3(
                cutleryPosition.transform.position.x,
                cutleryPosition.transform.position.y,
                cutleryPosition.transform.position.z),
                cutleryPosition.transform.rotation);
            cutleryCopy.tag = "Cutlery";
        }
    
        existingFood = foodCopy.AddComponent<Food>();
        isSpawning = false;
    }

    public void DestroyFood() 
    {
        if (existingFood != null)
        {
            Destroy(existingFood.gameObject);
            Destroy(cutleryCopy);

        }
    }

    private void Update()
    {
        if (existingFood != null && !isSpawning)
        {
            rayInteractor.keepSelectedTargetValid = true;
        }
    }
}
