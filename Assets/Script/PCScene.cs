using UnityEngine;
using UnityEngine.SceneManagement; // Thêm thư viện để làm việc với cảnh (scene)

public class PCScene : MonoBehaviour
{
    public string sceneNameToLoad; // Tên cảnh để tải
    public int documentsRequired = 1; // Số tài liệu cần thiết để chuyển cảnh
    private int documentsCollected = 0; // Số tài liệu đã thu thập

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Kiểm tra xem người chơi đã thu thập đủ tài liệu để chuyển cảnh chưa
            if (documentsCollected >= documentsRequired)
            {
                SceneManager.LoadScene(sceneNameToLoad); // Chuyển đến cảnh mới
            }
        }
    }

    // Phương thức để thông báo rằng một tài liệu đã được thu thập
    public void CollectDocument(int documentsNeeded)
    {
        documentsCollected += documentsNeeded;
    }

    // Phương thức để kiểm tra xem đã đủ tài liệu chưa
    public bool HasDocument()
    {
        return documentsCollected >= documentsRequired;
    }
}
