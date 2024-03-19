using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PC : MonoBehaviour
{
    //public CollectDocument collectedDocument;
    public CollectDocument[] collectibleDocuments;
    public bool isPCInterracted;
    void Start()
    {
        isPCInterracted = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPCInterracted |= true;

            DocumentManager documentManager = FindObjectOfType<DocumentManager>();
            if (documentManager != null && documentManager.AreAllDocumentsCollected())
            {
                SceneManager.LoadScene("PC_Screen");
            }
        }
    }

    //private bool AreAllDocumentsCollected()
    //{
    //foreach (CollectDocument doc in collectibleDocuments)
    // {
    // if (!doc.AreAllDocumentsCollected())
    //   {
    //       return false;
    //    }
    // }
    //return true;
    //  }
}


