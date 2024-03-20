using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    // Add your data fields here
    public int playerScore = 0;

    // Public getter for the instance
    public static DataManager Instance
    {
        get
        {
            // If the instance doesn't exist, try to find it in the scene
            if (instance == null)
            {
                instance = FindObjectOfType<DataManager>();

                // If it still doesn't exist, create a new GameObject to hold the DataManager
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("DataManager");
                    instance = singletonObject.AddComponent<DataManager>();
                }

                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    // You can add more methods and functions to manipulate your data here
}
