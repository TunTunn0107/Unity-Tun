using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Mover : MonoBehaviour
{
    public float speed = 5.0f;
    public float collectDistance = 0.5f;
    public List<GameObject> collectedObjects = new List<GameObject>();
    public Text scoreText;
    private int score = 0;
    private GameObject key; // Reference to the key GameObject
    private bool hasKey = false; // Flag to track whether the player has collected the key

    // Method to check if the player has collected the key
    public bool HasKey()
    {
        return hasKey;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, movement.normalized, movement.magnitude);

        if (hit.collider != null && hit.collider.tag == "InvisibleWall")
        {
            movement = Vector3.zero;
        }

        transform.position += movement * speed * Time.deltaTime;

        UpdateScoreText();

        if (key != null && hasKey)
        {
            key.transform.position = transform.position; // Make the key follow the player
        }
    }

    void CollectObject(GameObject collectible)
    {
        if (collectible.CompareTag("Key"))
        {
            hasKey = true; // Set hasKey flag to true when the player collects the key
            key = collectible; // Assign the key GameObject to the key variable
            collectible.SetActive(false); // Deactivate the key GameObject
        }

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
