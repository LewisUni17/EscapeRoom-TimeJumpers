using UnityEngine;
using NaughtyAttributes;

public class GameObjectSwitcher : MonoBehaviour
{
    [ReorderableList]
    public Transform[] parents; // List of potential parents for the game object

    [Button("Assign to Parent 1")]
    private void AssignToParent1()
    {
        AssignToParent(0);
    }

    [Button("Assign to Parent 2")]
    private void AssignToParent2()
    {
        AssignToParent(1);
    }

    [Button("Assign to Parent 3")]
    private void AssignToParent3()
    {
        AssignToParent(2);
    }

    private void AssignToParent(int index)
    {
        if (index >= 0 && index < parents.Length)
        {
            Transform newParent = parents[index];

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
        else
        {
            Debug.LogError("Invalid parent index!");
        }
    }
}
