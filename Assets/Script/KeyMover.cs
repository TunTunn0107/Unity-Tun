using UnityEngine;

public class KeyMover : MonoBehaviour
{
    public float minX = -5f; // Minimum X coordinate of the bounds
    public float maxX = 5f; // Maximum X coordinate of the bounds
    public float minY = -5f; // Minimum Y coordinate of the bounds
    public float maxY = 5f; // Maximum Y coordinate of the bounds
    public float speed = 0.5f; // Speed of movement, can be changed in the Inspector
    public float rotationSpeed = 3f; // Speed of rotation, can be changed in the Inspector
    public GameObject targetObject; // Reference to the target object

    private Vector2 destination;
    private Vector2 start;
    private float progress = 0.0f;
    private float rotOffset = 90f;

    private void Start()
    {
        start = transform.localPosition;
        progress = 0.0f;
        PickNewRandomDestination();
    }

    private void Update()
    {
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        bool reached = false;
        progress += speed * Time.deltaTime;
        if (progress >= 1.0f)
        {
            progress = 1.0f;
            reached = true;
        }

        transform.localPosition = Vector2.Lerp(start, destination, progress);

        if (reached)
        {
            start = destination;
            PickNewRandomDestination();
            progress = 0.0f;
        }

        RotateGameObject(destination, rotationSpeed, rotOffset);
    }

    private void PickNewRandomDestination()
    {
        destination = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    private void RotateGameObject(Vector2 destination, float rotationSpeed, float offset)
    {
        Vector3 dir = (Vector3)destination - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TargetObject"))
        {
            TargetObject target = other.GetComponent<TargetObject>();
            if (target != null)
            {
                target.ReceiveDocument();
                Destroy(gameObject); // Destroy the document object
            }
        }
    }

    private void EnsureWithinBounds()
    {
        // Ensure the key stays within the specified bounds after being released
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.position = newPosition;
    }
}
