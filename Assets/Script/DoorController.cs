using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorMission : MonoBehaviour
{
    public GameObject key; // Reference to the key GameObject
    private bool hasKey = false; // Flag to track if the player has collected the key

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && hasKey)
        {
            SceneManager.LoadScene("NextLevelScene"); // Transition to the next level scene
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && key.activeSelf)
        {
            CollectKey(); // Call method to collect the key
        }
    }

    private void CollectKey()
    {
        // Destroy or deactivate the key GameObject
        Destroy(key);
        hasKey = true; // Set the flag to indicate that the key has been collected
    }
}
