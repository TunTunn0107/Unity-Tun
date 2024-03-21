using System.Collections.Generic;
using UnityEngine;

public class DocumentManager : MonoBehaviour
{
    public List<string> requiredDocuments;
    private HashSet<string> collectedDocuments = new HashSet<string>();

    // Call this method when a document is collected
    public void CollectDocument(string documentID)
    {
        if (requiredDocuments.Contains(documentID))
        {
            collectedDocuments.Add(documentID);
        }
    }

    // Check if all required documents have been collected
    public bool AreAllDocumentsCollected()
    {
        return collectedDocuments.SetEquals(requiredDocuments);
    }
}
