using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        // Đảm bảo rằng GameObject chứa script này không bị hủy khi chuyển scene
       // DontDestroyOnLoad(gameObject);
        
        // Chuyển scene
        SceneManager.LoadScene(sceneName);
    }
}
