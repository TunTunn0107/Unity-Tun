using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public Sprite newSprite; // New sprite to set when all documents are dragged into this object
    public GameObject newGameObject; // GameObject to activate when all documents are received
    public int requiredDocuments = 3; // Number of documents required to change the sprite
    private int documentsReceived = 0; // Number of documents dragged into this object
    private bool hasChangedSprite = false; // Flag to track whether sprite has been changed

    // Method to increment documentsReceived and handle sprite change
    public void ReceiveDocument()
    {
        documentsReceived++;
        if (documentsReceived >= requiredDocuments && !hasChangedSprite)
        {
            GetComponent<SpriteRenderer>().sprite = newSprite;
            hasChangedSprite = true;

            // Activate the new GameObject
            if (newGameObject != null)
            {
                newGameObject.SetActive(true);
            }
            // Do any other actions you need when all documents are received and sprite is changed
        }
    }
}
