using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodProgress : MonoBehaviour
{
    public Image progressUI;
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
        progressUI.gameObject.SetActive(true);
        circleFill.fillAmount = fillTime;
        fillTime -= decreaseTime * Time.deltaTime;
    }

    void ResetCircle()
    {
        readyToFill = false;
        fillTime = 1;
        circleFill.fillAmount = fillTime;
        progressUI.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other != null && circleFill.fillAmount == 0)
        {
            if (other.transform.root != other.transform)
            {
                Destroy(other.transform.parent.gameObject);
                ResetCircle();
            }
            else
            {
                Destroy(other.gameObject);
                ResetCircle();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        readyToFill = true; 
    }

    private void OnTriggerExit(Collider other)
    {
        ResetCircle();
    }
}
