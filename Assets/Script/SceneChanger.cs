using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad; 

    public void ChangeBackScene()
    {
        // Lưu trữ dữ liệu của cảnh hiện tại
        DontDestroyOnLoad(gameObject);

        // Thay đổi cảnh
        SceneManager.LoadScene(sceneToLoad);
    }
}
