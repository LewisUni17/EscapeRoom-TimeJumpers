using UnityEngine;

public class Desk : MonoBehaviour
{
    public string toolTag = "Tool";
    public string deskTag = "Desk";
    public AudioClip deskInsertSound;
    public AutoDoors3 targetScript; // Reference to the target script

    private int toolsInHolder = 0;

    void Start()
    {
        // Ensure the target script is initially deactivated
        if (targetScript != null)
        {
            targetScript.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(toolTag))
        {
            Tool tool = other.GetComponent<Tool>();
            if (tool != null && !tool.IsInHolder())
            {
                tool.SetInHolder(true);
                toolsInHolder++;

                Debug.Log("Tools in Holder: " + toolsInHolder);

                if (toolsInHolder == 4)
                {
                    PlayDeskInsertSound();
                    ActivateTargetScript(); // Activate the target script
                }
            }
        }
    }

    private void PlayDeskInsertSound()
    {
        if (deskInsertSound != null)
        {
            AudioSource.PlayClipAtPoint(deskInsertSound, transform.position);
        }
    }

    private void ActivateTargetScript()
    {
        if (targetScript != null)
        {
            targetScript.enabled = true; // Activate the target script
        }
    }
}
