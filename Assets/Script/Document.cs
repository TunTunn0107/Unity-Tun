using UnityEngine;

public class Document : MonoBehaviour
{
    public PCScene pcScene; // Tham chiếu đến script PCScene
    public int documentsNeeded = 1; // Số tài liệu cần thiết để chuyển cảnh

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Kiểm tra xem người chơi có thể thu thập tài liệu này không (tài liệu đang hiện hữu và chưa được thu thập)
            if (gameObject.activeSelf && !pcScene.HasDocument())
            {
                pcScene.CollectDocument(documentsNeeded); // Thông báo cho cảnh rằng một tài liệu đã được thu thập
                gameObject.SetActive(false); // Deactivate tài liệu
            }
        }
    }
}
