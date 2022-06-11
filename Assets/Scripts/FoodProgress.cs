using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodProgress : MonoBehaviour
{
    public Image ProgressUI;
    public Image circleFill;

    private float fillTime = 1;
    private float decreaseTime = 0.33f;
    private bool readyToFill = false;


    private void Update()
    {
        if (readyToFill)
        {
            FillCircle();       
        }
    }

    void FillCircle()
    {
        ProgressUI.gameObject.SetActive(true);
        circleFill.fillAmount = fillTime;
        fillTime -= decreaseTime * Time.deltaTime;
    }

    void resetCircle()
    {
        readyToFill = false;
        fillTime = 1;
        circleFill.fillAmount = fillTime;
        ProgressUI.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other != null && circleFill.fillAmount == 0)
        {
            Destroy(other.gameObject);
            resetCircle();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        readyToFill = true; 
    }

    private void OnTriggerExit(Collider other)
    {
        resetCircle();
    }
}
