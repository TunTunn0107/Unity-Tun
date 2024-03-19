using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject teleportDestination; // Destination to teleport to
    public int keysRequired = 1; // Number of keys required to open the door
    private int keysCollected = 0; // Number of keys collected for this door

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the player has collected enough keys to open the door
            if (keysCollected >= keysRequired)
            {
                // Teleport the player to the destination
                other.transform.position = teleportDestination.transform.position;
            }
        }
    }

    // Method to notify the door that a key has been collected
    public void CollectKey(int keysNeeded)
    {
        keysCollected += keysNeeded;
    }

    // Method to check if the door has enough keys to open
    public bool HasKey()
    {
        return keysCollected >= keysRequired;
    }

    // Method to open the door
    public void OpenDoor()
    {
        // Implement your door opening logic here
        // For example, you can play an animation, change the door's state, etc.
        Debug.Log("Door opened!"); // Placeholder message
    }
}
