using UnityEngine;

public class SoundOnCollision : MonoBehaviour
{
    public AudioClip soundEffect; // âm thanh muốn phát ra khi xảy ra va chạm
    private AudioSource audioSource; // Thành phần AudioSource để phát âm thanh

    private void Start()
    {
        // Kiểm tra xem đã gán AudioClip vào soundEffect chưa
        if (soundEffect == null)
        {
            Debug.LogError("Sound effect is not assigned!");
            enabled = false; // Tắt script nếu không có âm thanh được gán
            return;
        }

        // Lấy thành phần AudioSource từ GameObject hoặc thêm một mới nếu cần
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Gán âm thanh muốn phát ra vào thành phần AudioSource
        audioSource.clip = soundEffect;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra xem va chạm có phải là với Player không
        if (collision.gameObject.CompareTag("Player"))
        {
            // Phát ra âm thanh
            audioSource.Play();
        }
    }
}
