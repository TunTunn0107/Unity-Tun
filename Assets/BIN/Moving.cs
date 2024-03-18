using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed = 5.0f;

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        transform.position += movement * speed * Time.deltaTime;
    }
}
