using UnityEngine;

public class DocumentMover : MonoBehaviour
{
    public float minX = -5f; // Minimum X coordinate of the bounds
    public float maxX = 5f; // Maximum X coordinate of the bounds
    public float minY = -5f; // Minimum Y coordinate of the bounds
    public float maxY = 5f; // Maximum Y coordinate of the bounds
    public float speed = 0.5f; // Speed of movement, can be changed in the Inspector
    public float rotationSpeed = 3f; // Speed of rotation, can be changed in the Inspector
    public Sprite newSprite; // New sprite to set when object is dragged into another object
    public GameObject targetObject; // Reference to the target object
    public int maxDocuments = 3; // Maximum number of documents to be dragged into the target object

    private Vector2 baseStartPosition;
    private Vector2 destination;
    private Vector2 start;
    private float progress = 0.0f;

    private float rotOffset = 90f;

    private bool isMoving = true; // Flag to control movement
    private bool isDragging = false; // Flag to control dragging state
    private bool canDrag = true; // Flag to control dragging availability

    private int documentsInTarget = 0; // Number of documents dragged into the target object

    private void Start()
    {
        start = transform.localPosition;
        baseStartPosition = transform.localPosition;
        progress = 0.0f;

        PickNewRandomDestination();
    }

    private void Update()
    {
        if (!isMoving || isDragging) return; // If not moving or dragging, return without updating

        bool reached = false;
        progress += speed * Time.deltaTime;

        if (progress >= 1.0f)
        {
            progress = 1.0f;
            reached = true;
        }

        transform.localPosition = (destination * progress) + start * (1 - progress);

        if (reached)
        {
            start = destination;
            PickNewRandomDestination();
            progress = 0.0f;
        }

        RotateGameObject(destination, rotationSpeed, rotOffset);

        // Ensure the document stays within the bounds
        Vector3 newPosition = transform.localPosition;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.localPosition = newPosition;
    }

    private void PickNewRandomDestination()
    {
        // Generate random destination within the bounds
        destination = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    private void RotateGameObject(Vector2 destination, float rotationSpeed, float offset)
    {
        Vector3 target = destination;
        Vector3 dir = target - (Vector3)transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        if (!canDrag) return; // If dragging is disabled, return without updating

        isMoving = false;
        isDragging = true;
        canDrag = true; // Disable dragging until mouse button is released
    }

    private void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    private void OnMouseUp()
    {
        isMoving = true;
        isDragging = false;
        canDrag = true; // Enable dragging when mouse button is released
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!canDrag) return; // If dragging is disabled, return without updating

        // Check if the object is being dragged into another object
        if (isDragging && other.CompareTag("TargetObject"))
        {
            // Change the sprite of the current object
            GetComponent<SpriteRenderer>().sprite = newSprite;
            canDrag = false; // Disable dragging until mouse button is released

            // Increment the count of documents in the target object
            documentsInTarget++;

            // Check if the maximum number of documents has been reached
            if (documentsInTarget >= maxDocuments)
            {
                // Change the sprite of the target object
                targetObject.GetComponent<SpriteRenderer>().sprite = newSprite;
            }
        }
    }
}
