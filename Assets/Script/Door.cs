using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load when the door is opened

    private bool isOpen = false;

    public void OpenDoor()
    {
        isOpen = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isOpen)
        {
            // Transition to the next scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
