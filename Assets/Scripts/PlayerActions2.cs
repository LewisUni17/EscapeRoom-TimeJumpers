using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions2 : MonoBehaviour
{

    private void OnTriggerStay(Collider other)      // Method to activate the doors
    {
        if (other.tag == "Door2")
        {
            if (other.GetComponent<AutoDoors2>().Moving == false)
            {
                other.GetComponent<AutoDoors2>().Moving = true;
            }
        }
    }
}