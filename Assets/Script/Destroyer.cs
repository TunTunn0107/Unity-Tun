using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") // Assuming character has "Mover" tag
        {
            // Destroy the object
            Destroy(gameObject);
        }
    }
}