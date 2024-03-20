using UnityEngine;

public class PlayerCollisionSound : MonoBehaviour
{
    public AudioClip collisionSound; // âm thanh bạn muốn phát ra khi player va chạm

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Kiểm tra xem player có va chạm với đối tượng nào không
        // Ví dụ: nếu player va chạm với đối tượng có tag là "Document"
        if (other.gameObject.CompareTag("Document"))
        {
            // Phát âm thanh khi va chạm
            AudioSource.PlayClipAtPoint(collisionSound, transform.position);
        }
    }
}
