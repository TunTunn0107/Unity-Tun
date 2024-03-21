using UnityEngine;

public class CollectDocument : MonoBehaviour
{
    public string documentID; // Unique identifier for the document

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DocumentManager documentManager = FindObjectOfType<DocumentManager>();
            if (documentManager != null)
            {
                documentManager.CollectDocument(documentID);
                Destroy(gameObject); // Destroy the document after collection
            }
        }
    }
}
