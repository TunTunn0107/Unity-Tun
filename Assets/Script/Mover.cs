using UnityEngine;
using System.Collections.Generic; // For List<>
using UnityEngine.UI; // For Text class

public class Mover : MonoBehaviour
{
    public float speed = 5.0f; // Movement speed
    public float collectDistance = 0.5f; // Distance for collection raycast
    public List<GameObject> collectedObjects = new List<GameObject>(); // Collection to store collected objects
    public Text scoreText; // Reference to UI Text object for displaying score
    private int score = 0; // Stores current score

    void Update()
    {
        // Movement logic
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        // Raycast for collision detection
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movement.normalized, movement.magnitude);

        // Check for collision with a wall (using tag)
        if (hit.collider != null && hit.collider.tag == "Wall")
        {
            // Cancel movement if colliding with a wall
            movement = Vector3.zero;
        }

        // Apply movement
        transform.position += movement * speed * Time.deltaTime;

        // Check for object interaction (handled elsewhere, optional)
        // ... (code for object interaction, if needed)

        UpdateScoreText(); // Update score display after interaction or movement
    }

    void CollectObject(GameObject collectible)
    {
        // Code for collecting objects (handled elsewhere, optional)
        // ... (add logic for collecting objects, if needed)
        collectedObjects.Add(collectible);
        score++;
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
