using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Added for scene management

public class Mover : MonoBehaviour
{
    public float speed = 5.0f;
    public float collectDistance = 0.5f;
    public List<GameObject> collectedObjects = new List<GameObject>();
    public Text scoreText;
    private int score = 0;
    private bool hasKey = false; // Flag to track whether the player has collected the key

    public string sceneToLoad; // Name of the scene to load
    public GameObject door; // Reference to the door GameObject
    public GameObject key; // Reference to the key GameObject

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
    }

    public void CollectKey()
    {
        hasKey = true;
        key.SetActive(false); // Deactivate the key GameObject
        // Optionally, update UI or perform other actions when the key is collected
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door") && hasKey)
        {
            // Open the door if the player has the key
            door.SetActive(false); // Deactivate the door GameObject
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
