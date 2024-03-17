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
        transform.position += movement * speed * Time.deltaTime;

        // Check for object interaction
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, collectDistance);
        if (hit.collider != null)
        {
            GameObject objectToInteract = hit.collider.gameObject;

            if (objectToInteract.tag == "Collectible") // Collect and follow
            {
                CollectObject(objectToInteract);
                score++; // Increase score for collecting
            }
            else if (objectToInteract.tag == "Destroyable") // Destroy
            {
                Destroy(objectToInteract);
            }

            UpdateScoreText(); // Update score display after interaction
        }
    }

    void CollectObject(GameObject collectible)
    {
        collectedObjects.Add(collectible);
        collectible.transform.parent = transform;
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
