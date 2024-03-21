using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Transform[] waypoints; // Các điểm đến mà NPC sẽ di chuyển giữa chúng
    public float moveSpeed = 3f; // Tốc độ di chuyển của NPC
    private int currentWaypointIndex = 0; // Chỉ số của điểm đến hiện tại mà NPC đang di chuyển tới
    private Vector3 lastWaypointDirection; // Hướng từ vị trí hiện tại của NPC đến điểm đến cuối cùng

    private void Start()
    {
        // Đảm bảo rằng có ít nhất một điểm đến
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned to NPCMovement script!");
            enabled = false; // Tắt script nếu không có điểm đến nào được gán
            return;
        }

        // Đặt vị trí ban đầu của NPC là điểm đầu tiên
        transform.position = waypoints[currentWaypointIndex].position;

        // Tính toán hướng từ vị trí hiện tại của NPC đến điểm đến đầu tiên
        lastWaypointDirection = (waypoints[currentWaypointIndex].position - transform.position).normalized;
    }

    private void Update()
    {
        // Di chuyển NPC tới điểm đến hiện tại
        MoveToWaypoint();

        // Kiểm tra nếu NPC đã đến điểm đến hiện tại
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // Tính toán hướng mới từ vị trí hiện tại của NPC đến điểm đến tiếp theo
            Vector3 newWaypointDirection = (waypoints[(currentWaypointIndex + 1) % waypoints.Length].position - transform.position).normalized;

            // Kiểm tra hướng mới so với hướng trước đó
            if (Vector3.Dot(newWaypointDirection, lastWaypointDirection) < 0)
            {
                // Flip hướng của NPC nếu hướng mới và hướng cũ có độ lệch lớn
                Flip();
            }

            // Cập nhật hướng cũ sang hướng mới
            lastWaypointDirection = newWaypointDirection;

            // Chuyển sang điểm đến tiếp theo
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    private void MoveToWaypoint()
    {
        // Di chuyển NPC tới điểm đến hiện tại
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);
    }

    private void Flip()
    {
        // Flip hướng của NPC bằng cách đảo chiều Scale theo trục X
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
