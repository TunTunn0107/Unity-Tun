using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeNextScene : MonoBehaviour
{
    public int sceneBuildIndex;
    public GameObject door; // Reference to the door GameObject
    private bool doorLocked = true; // Flag to track if the door is locked

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the door is unlocked or if the player has collected the key
            if (!doorLocked || other.GetComponent<Mover>().HasKey())
            {
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            }
        }
    }

    // This method is called when the player collects the key
    public void UnlockDoor()
    {
        doorLocked = false; // Unlock the door
    }
}
