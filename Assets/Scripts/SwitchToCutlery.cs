using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchToCutlery : MonoBehaviour
{
    //
    public Transform controllerModel;
    //

    private Collider objectCollider;


    private void Start()
    {
        objectCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && objectCollider.gameObject.tag == "")
        {

        }     
    }
}
