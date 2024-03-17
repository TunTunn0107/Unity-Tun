using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("Collision Detected with " + other.gameObject.name); // Check if collision is detected
    if (other.CompareTag("Player")) // Assuming character has "Player" tag
    {
        // Stop the player's movement by setting their velocity to zero
        Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = Vector2.zero;
            Debug.Log("Player stopped."); // Confirm player stopped moving
        }
    }
}

}
