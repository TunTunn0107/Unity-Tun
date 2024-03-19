using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PC : MonoBehaviour
{
    public string nextSceneName;
    public CollectDocument[] collectibleDocuments;
    public bool isPCInterracted;
    public bool isNotified; // Declare isNotified variable

    void Start()
    {
        isPCInterracted = false;
        isNotified = false; // Initialize isNotified variable
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPCInterracted |= true;

            DocumentManager documentManager = FindObjectOfType<DocumentManager>();
            if (documentManager != null && documentManager.AreAllDocumentsCollected())
            {
                SceneManager.LoadScene(nextSceneName);
                isNotified = true; // Set isNotified to true when all documents are collected
            }
        }
    }
}
