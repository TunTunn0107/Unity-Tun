using UnityEngine;

public class DocumentMover : MonoBehaviour
{
    public float minX = -5f; // Minimum X coordinate of the bounds
    public float maxX = 5f; // Maximum X coordinate of the bounds
    public float minY = -5f; // Minimum Y coordinate of the bounds
    public float maxY = 5f; // Maximum Y coordinate of the bounds

    //private float radius = 0.8f;
    private float speed = 0.5f;
    private Vector2 baseStartPosition;
    private Vector2 destination;
    private Vector2 start;
    private float progress = 0.0f;

    private float rotOffset = 90f;
    private float rotationSpeed = 3f;

    private void Start()
    {
        start = transform.localPosition;
        baseStartPosition = transform.localPosition;
        progress = 0.0f;

        PickNewRandomDestination();
    }

    private void Update()
    {
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
}
