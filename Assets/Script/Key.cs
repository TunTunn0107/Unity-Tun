using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Collect the key
            Mover moverScript = other.GetComponent<Mover>();
            if (moverScript != null)
            {
                moverScript.CollectKey();
                // Destroy the key GameObject
                Destroy(gameObject);
            }
        }
    }
}
