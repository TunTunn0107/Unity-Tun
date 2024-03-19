using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PC : MonoBehaviour
{
    // Create a public variable to store the name of the scene you want to transition to
    public string nextSceneName;

    //public CollectDocument collectedDocument;
    public CollectDocument[] collectibleDocuments;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if all documents have been collected
            if (AreAllDocumentsCollected())
            {
                // If all documents have been collected, transition to the next scene
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }

    private bool AreAllDocumentsCollected()
    {
        // Check each collected document
        foreach (CollectDocument doc in collectibleDocuments)
        {
            // If any document is not collected, return false
            if (!doc.isCollected)
            {
                return false;
            }
        }
        // If all documents are collected, return true
        return true;
    }
}
