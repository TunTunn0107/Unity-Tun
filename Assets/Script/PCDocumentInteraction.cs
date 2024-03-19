using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PCDocumentInteraction : MonoBehaviour
{
    public string nextSceneName;
    public CollectDocument[] collectibleDocuments;
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
                SceneManager.LoadScene(nextSceneName);
                DontDestroyOnLoad(gameObject);
                isNotified = true; 
            }
            else
            {
                isNotified = false; // Set isNotified to false if not all documents are collected
            }
        }
    }
}
