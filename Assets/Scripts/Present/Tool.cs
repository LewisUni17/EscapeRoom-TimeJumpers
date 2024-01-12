using UnityEngine;

public class Tool : MonoBehaviour
{
    private bool isInHolder = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Desk"))
        {
            // Optionally, you can perform additional checks here if needed
            SetInHolder(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Desk"))
        {
            SetInHolder(false);
        }
    }

    public bool IsInHolder()
    {
        return isInHolder;
    }

    public void SetInHolder(bool value)
    {
        isInHolder = value;
    }
}
