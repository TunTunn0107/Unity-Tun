using UnityEngine;

public class Key : MonoBehaviour
{
    public DoorOpen doorOpen; // Reference to the DoorOpen script associated with this key
    public int keysNeeded = 1; // Number of keys needed to open the door

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the player can collect this key (key is active and not already collected)
            if (gameObject.activeSelf && !doorOpen.HasKey())
            {
                doorOpen.CollectKey(keysNeeded); // Notify the door that a key has been collected
                gameObject.SetActive(false); // Deactivate the key
            }
        }
    }
}
