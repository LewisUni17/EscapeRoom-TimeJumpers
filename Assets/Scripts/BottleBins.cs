using UnityEngine;

public class Bin : MonoBehaviour
{
    public string bottleTag = "Bottle";
    public string binTag = "Bin";
    public AudioClip bottleInsertSound;
    public AutoDoors2 targetScript1; // Reference to the first target script
    public AutoDoors2 targetScript2; // Reference to the second target script

    private int bottlesInBin = 0;

    void Start()
    {
        // Ensure the target scripts are initially deactivated
        if (targetScript1 != null)
        {
            targetScript1.enabled = false;
        }

        if (targetScript2 != null)
        {
            targetScript2.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(bottleTag))
        {
            Bottle bottle = other.GetComponent<Bottle>();
            if (bottle != null && !bottle.IsInBin())
            {
                bottle.SetInBin(true);
                bottlesInBin++;

                if (bottlesInBin == 6)
                {
                    PlayBottleInsertSound();
                    ActivateTargetScripts(); // Activate both target scripts
                }
            }
        }
    }

    private void PlayBottleInsertSound()
    {
        if (bottleInsertSound != null)
        {
            AudioSource.PlayClipAtPoint(bottleInsertSound, transform.position);
        }
    }

    private void ActivateTargetScripts()
    {
        if (targetScript1 != null)
        {
            targetScript1.enabled = true; // Activate the first target script
        }

        if (targetScript2 != null)
        {
            targetScript2.enabled = true; // Activate the second target script
        }
    }
}
