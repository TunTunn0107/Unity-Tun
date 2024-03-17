using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Add any additional properties or behaviors for the collectible object here
    // ... (optional)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mover") // Assuming character has "Mover" tag
        {
            // Trigger collection behavior (handled by Mover script)
        }
    }
}
