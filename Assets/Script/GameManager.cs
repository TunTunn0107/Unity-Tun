using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; // Static instance of GameManager which allows it to be accessed by any other script.

    // Data to persist between scenes
    public int score;
    // Add more data you want to persist between scenes

    void Awake()
    {
        // Check if instance already exists
        if (instance == null)
        {
            // if not, set instance to this
            instance = this;
        }
        // If instance already exists and it's not this:
        else if (instance != this)
        {
            // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);    
        }

        // Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        // Example: Press 'L' to load a new scene
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadScene("YourSceneNameHere");
        }
    }
}
