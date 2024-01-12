using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    private void OnTriggerStay(Collider other)      // Method to activate the doors
    {
        if (other.tag == "Door")
        {
            if (other.GetComponent<AutoDoors>().Moving == false)
            {
                other.GetComponent<AutoDoors>().Moving = true;
            }
        }
    }

}