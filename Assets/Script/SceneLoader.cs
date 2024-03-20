// Định nghĩa không gian tên mới, ví dụ: MyScripts
namespace MyScripts
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SceneLoader : MonoBehaviour
    {
        public void LoadSceneByName(string sceneName)
        {
           
            // Chuyển scene
            SceneManager.LoadScene(sceneName);
        }
    }
}
