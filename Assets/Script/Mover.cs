using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Mover : MonoBehaviour
{
    public float speed = 5.0f;
    public float collectDistance = 0.5f;
    public List<GameObject> collectedObjects = new List<GameObject>();
    public Text scoreText;
    public GameObject keyPrefab; // Reference to the key prefab
    private int totalDocuments = 5; // Total number of documents to collect
    private int collectedDocuments = 0; // Number of documents collected
    private GameObject key; // Reference to the key GameObject
    private bool hasKey = false; // Flag to track whether the player has collected the key

    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    // Method to check if the player has collected the key
    public bool HasKey()
    {
        return hasKey;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
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

        // Flip character sprite if moving left or right
        if (movement.x != 0)
        {
            spriteRenderer.flipX = movement.x < 0; // Flip character sprite if moving left
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Document"))
        {
            collectedDocuments++;
            Destroy(other.gameObject); // Destroy the document object
            CheckDocumentsCollected();
        }
    }

    void CheckDocumentsCollected()
    {
        if (collectedDocuments == totalDocuments && !hasKey)
        {
            SpawnKey(); // Spawn the key if all documents are collected and key doesn't exist
        }
    }

    void SpawnKey()
    {
        if (keyPrefab != null && key == null)
        {
            key = Instantiate(keyPrefab, transform.position, Quaternion.identity);
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Documents Collected: " + collectedDocuments + " / " + totalDocuments;
        }
    }
}
