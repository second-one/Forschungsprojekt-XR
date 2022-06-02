using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FoodManager : MonoBehaviour
{
    public GameObject[] foodToSpawn;

    public Food existingFood;

    //
    public GameObject rightHandModel;
    public ActionBasedController controllerManager;
    private SwitchToCutlery changeModel;
    //
    
  //  private void Start()
  //  {
  //      controllerManager = rightHandModel.GetComponent<ActionBasedController>();
   // }

    public void SpawnFoodSource (int index) 
    {
        DestroyFood();

        var foodCopy = Instantiate(foodToSpawn[index], new Vector3(transform.position.x, 2.2f, transform.position.z), transform.rotation);
        existingFood = foodCopy.AddComponent<Food>();

        //
        controllerManager.modelPrefab = changeModel.controllerModel;
        print(controllerManager.modelPrefab);
        //
    }
        
        
      // foodCopy.tag = "Copy";
      // foreach (Transform t in foodCopy.transform)
      // {
      //   t.gameObject.tag = "Copy";
      // }

    

    public void DestroyFood() 
    {
        if (existingFood != null)
        {
            Destroy(existingFood.gameObject);
            //Destroy(GameObject.FindWithTag("Copy"));

        }
    }

}
