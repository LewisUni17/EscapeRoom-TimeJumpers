using UnityEngine;

public class SwordHolder : MonoBehaviour
{
    public string swordTag = "Sword";
    public string holderTag = "SwordHolder";
    public AudioClip swordInsertSound;
    public AutoDoors targetScript; // Reference to the target script

    private int swordsInHolder = 0;

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
        if (other.CompareTag(swordTag))
        {
            Sword sword = other.GetComponent<Sword>();
            if (sword != null && !sword.IsInHolder())
            {
                sword.SetInHolder(true);
                swordsInHolder++;

                Debug.Log("Swords in Holder: " + swordsInHolder);

                if (swordsInHolder == 6)
                {
                    PlaySwordInsertSound();
                    ActivateTargetScript(); // Activate the target script
                }
            }
        }
    }

    private void PlaySwordInsertSound()
    {
        if (swordInsertSound != null)
        {
            AudioSource.PlayClipAtPoint(swordInsertSound, transform.position);
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
