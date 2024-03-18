using UnityEngine;

public class CharacterMovementWithInvisibleWall : MonoBehaviour
{
    public Rect movementBounds; // Define the invisible wall boundaries
    public float movementSpeed = 5f; // Adjust character's movement speed
    public float bounceFactor = 0.5f; // Control bounce effect when hitting the wall

    private Rigidbody2D rb2d; // Assuming 2D movement (replace with Rigidbody for 3D)

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movement input (replace with your actual movement logic)
        Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Apply movement
        rb2d.velocity = movementInput * movementSpeed;

        // Enforce invisible wall boundaries
        EnforceBounds();
    }

    void EnforceBounds()
    {
        var position = transform.position;

        // Clamp position to create the invisible wall effect
        position.x = Mathf.Clamp(position.x, movementBounds.xMin, movementBounds.xMax);
        position.y = Mathf.Clamp(position.y, movementBounds.yMin, movementBounds.yMax);

        // Optionally add a visual bounce effect
        Vector2 adjustment = transform.position - position; // Vector representing how much to adjust
        rb2d.velocity = adjustment * bounceFactor; // Apply bounce force

        transform.position = position;
    }
}
