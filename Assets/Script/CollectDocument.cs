using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDocument : MonoBehaviour
{
    public bool isCollected;
    // public int requiredDocuments = 3;
    // private int collectedDocuments = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DocumentManager documentManager = FindObjectOfType<DocumentManager>();
            if (documentManager != null)
            {
                documentManager.CollectDocument();
                Destroy(gameObject);
            }
        }
    }

    // private void CollectedDocument()
    //{
      //  isCollected = true;
      //  collectedDocuments++;
      //  Destroy(gameObject);
    //}

    //cái code dưới này là để dành cho 1 document duy nhất
    //public bool IsDocumentCollected()
    //{
       // return isCollected;
   // }

}
