using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CutleryManager : MonoBehaviour
{
    public FoodManager foodData;
        
    public void DestroyCutlery()
    {
        foodData.DestroyFood();
    }


}
