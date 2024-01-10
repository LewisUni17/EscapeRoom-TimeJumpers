using UnityEngine;

public class SwordHolder : MonoBehaviour
{
    public string swordTag = "Sword";
    public string holderTag = "Swordholder";
    public AudioClip swordInsertSound;

    private int swordsInHolder = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(swordTag))
        {
            // Check if the sword is not already in the holder
            Sword sword = other.GetComponent<Sword>();
            if (sword != null && !sword.IsInHolder())
            {
                sword.SetInHolder(true);
                swordsInHolder++;

                // Check if all swords are in the holder
                if (swordsInHolder == 3)
                {
                    PlaySwordInsertSound();
                    // Perform any other actions or triggers you want here
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
}
