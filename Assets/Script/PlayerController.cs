using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private bool hasKey = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            CollectKey();
        }
        else if (other.CompareTag("Door") && hasKey)
        {
            OpenDoor();
        }
    }

    private void CollectKey()
    {
        hasKey = true;
        // Optionally, play a sound or show a message indicating key collection
        Destroy(gameObject); // Destroy the key GameObject
    }

    private void OpenDoor()
    {
        // Load the destination scene
        SceneManager.LoadScene("DestinationSceneName");
    }
}
