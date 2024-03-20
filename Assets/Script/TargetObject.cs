using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public Sprite newSprite; // New sprite to set when all documents are dragged into this object
    public int requiredDocuments = 3; // Number of documents required to change the sprite
    private int documentsReceived = 0; // Number of documents dragged into this object
    private bool hasChangedSprite = false; // Flag to track whether sprite has been changed

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Document"))
        {
            documentsReceived++;
            Destroy(other.gameObject); // Destroy the document object once it's dragged into the target object

            if (documentsReceived >= requiredDocuments && !hasChangedSprite)
            {
                GetComponent<SpriteRenderer>().sprite = newSprite;
                hasChangedSprite = true;
                // Do any other actions you need when all documents are received and sprite is changed
            }
        }
    }
}
