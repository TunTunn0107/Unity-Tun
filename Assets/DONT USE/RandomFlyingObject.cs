using UnityEngine;

public class RandomFlyingObject : MonoBehaviour
{
    public Rect areaBounds;
    public float speed = 2f;
    public float changeDirectionFrequency = 1f; // Seconds between direction changes

    private Rigidbody2D rb2d;
    private Vector2 direction;
    private float nextDirectionChangeTime = 0;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        direction = RandomDirection();
    }

    void Update()
    {
        if (Time.time > nextDirectionChangeTime)
        {
            direction = RandomDirection();
            nextDirectionChangeTime = Time.time + changeDirectionFrequency;
        }

        rb2d.velocity = direction * speed;
        ClampToArea();
    }

    Vector2 RandomDirection()
    {
        float angle = Random.Range(0, 360);
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    void ClampToArea()
    {
        var position = transform.position;
        position.x = Mathf.Clamp(position.x, areaBounds.xMin, areaBounds.xMax);
        position.y = Mathf.Clamp(position.y, areaBounds.yMin, areaBounds.yMax);
        transform.position = position;
    }
}
