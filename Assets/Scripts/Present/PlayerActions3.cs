using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions3 : MonoBehaviour
{

    private void OnTriggerStay(Collider other)      // Method to activate the doors
    {
        if (other.tag == "Door3")
        {
            if (other.GetComponent<AutoDoors3>().Moving == false)
            {
                other.GetComponent<AutoDoors3>().Moving = true;
            }
        }
    }

}