using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentManager : MonoBehaviour
{
    public int requiredDocuments;
    private int collectedDocuments;

    public void CollectDocument()
    {
        collectedDocuments++;
    }

    public bool AreAllDocumentsCollected()
    {
        return collectedDocuments >= requiredDocuments;
    }
}
