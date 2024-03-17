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

    void CollectObject(GameObject collectible)
    {
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
