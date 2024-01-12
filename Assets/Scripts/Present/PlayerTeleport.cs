using UnityEngine;
using NaughtyAttributes;

public class GameObjectSwitcher : MonoBehaviour
{
    [ReorderableList]
    public Transform[] parents; // List of potential parents for the game object

    private float timer = 60f; // Timer in seconds
    private float countdown;

    private void Start()
    {
        countdown = timer; // Start the countdown
    }

    private void Update()
    {
        // Update the countdown
        countdown -= Time.deltaTime;

        // Check if the timer has reached zero
        if (countdown <= 0f)
        {
            AssignToNextParent(); // Switch to the next parent
            countdown = timer; // Reset the countdown
        }
    }

    [Button("Assign to Next Parent")]
    private void AssignToNextParent()
    {
        // Find the current parent index
        int currentIndex = System.Array.IndexOf(parents, transform.parent);

        // Calculate the next index
        int nextIndex = (currentIndex + 1) % parents.Length;

        // Get the next parent
        Transform newParent = parents[nextIndex];

        // Store the current local transform
        Vector3 localPosition = transform.localPosition;
        Quaternion localRotation = transform.localRotation;
        Vector3 localScale = transform.localScale;

        // Change the parent
        transform.parent = newParent;

        // Restore the stored local transform
        transform.localPosition = localPosition;
        transform.localRotation = localRotation;
        transform.localScale = localScale;

        Debug.Log($"Teleported to {newParent.name}!");
    }
}
