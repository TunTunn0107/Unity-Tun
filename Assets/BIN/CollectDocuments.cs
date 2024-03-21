using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectDocuments : MonoBehaviour
{
    public int requiredDocument = 3;
    public int collectedDocument = 0;
    public TextMeshProUGUI documentCountText;

    public void Start()
    {
        UpdateDocumentCountUI();
    }


    private void UpdateDocumentCountUI()
    {
        if (documentCountText != null)
        {
            documentCountText.text = "Document: " + collectedDocument.ToString();
        }
        else
        {
            Debug.LogWarning("KeyCountText is not assigned in the KeyCollector script.");
        }
    }
}
