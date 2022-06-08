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

    private GameObject cutleryCopy;
   /* public CutleryManager cutleryObject;*/

/*  public GameObject rightHandModel;
    public ActionBasedController controllerManager;
    private SwitchToCutlery changeModel; */

/*  private void Start() { controllerManager = rightHandModel.GetComponent<ActionBasedController>(); } */


    public void SpawnFoodSource (int index) 
    {
        
        DestroyFood();
        /*cutleryObject.DestroyCutlery();*/
        
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
        }

        existingFood = foodCopy.AddComponent<Food>();
       
        
        
/*      controllerManager.modelPrefab = changeModel.controllerModel;
        print(controllerManager.modelPrefab);*/
        
    }
  
/*    foodCopy.tag = "Copy";
      foreach (Transform t in foodCopy.transform)
      {
      t.gameObject.tag = "Copy";
      }*/  

    public void DestroyFood() 
    {
        if (existingFood != null)
        {
            Destroy(existingFood.gameObject);
            Destroy(cutleryCopy);

        }
    }
}
