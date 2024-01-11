using UnityEngine;

public class Bottle : MonoBehaviour
{
    private bool isInBin = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bin"))
        {
            // Optionally, you can perform additional checks here if needed
            SetInBin(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bin"))
        {
            SetInBin(false);
        }
    }

    public bool IsInBin()
    {
        return isInBin;
    }

    public void SetInBin(bool value)
    {
        isInBin = value;
    }
}
