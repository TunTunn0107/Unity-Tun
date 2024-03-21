using UnityEngine;
using UnityEngine.SceneManagement;

public class PCDocumentInteraction : MonoBehaviour
{
    public string nextSceneName;

    public bool isPCInterracted;
    public bool isNotified; 

    void Start()
    {
        isPCInterracted = false;
        isNotified = false; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPCInterracted = true;

            DocumentManager documentManager = FindObjectOfType<DocumentManager>();
            if (documentManager != null && documentManager.AreAllDocumentsCollected())
            {
                SceneManager.LoadScene(nextSceneName); // Load the next scene
                DontDestroyOnLoad(gameObject); // Keep this game object across scenes
                isNotified = true; 
            }
            else
            {
                isNotified = false; // Not all documents are collected, so don't proceed to the next scene
            }
        }
    }
}
