using UnityEngine;
using TMPro;

public class Lock_notification : MonoBehaviour
{
    public TextMeshProUGUI notificationText; // Reference to the notification text object
    public DoorOpen door; // Reference to the DoorOpen script associated with this door
    private bool notified = false; // Flag to track if the notification is currently active

    void Start()
    {
        notificationText.gameObject.SetActive(false); // Initially hide the notification
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the player does not have enough keys to open the door
            if (!door.HasKey())
            {
                // Display the notification if it's not already active
                if (!notified)
                {
                    notificationText.gameObject.SetActive(true);
                    notified = true;
                }
            }
            else
            {
                // If the player has enough keys, hide the notification and open the door
                notificationText.gameObject.SetActive(false);
                door.OpenDoor(); // Assuming you have a method to open the door in the DoorOpen script
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide the notification when the player moves away from the door
            notificationText.gameObject.SetActive(false);
            notified = false;
        }
    }
}
