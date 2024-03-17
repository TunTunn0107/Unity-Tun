using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    //create an instance for scene controller to access it anywhere
    private void Awake()
    {
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            //don't destroy this object when load new scene
            else
            {
                Destroy(gameObject);
            }
            //if it already have this object then destroy
        }
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //using buildIndex + 1 will load the next scene on the list of scene in your build manager (check File > Build Setting > Scene in Build to know which is active)

    }
    public void LoadScene(string sceneName)
    //use this to make a scene parameter in Unity, we can go to the scene we want 
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

}
