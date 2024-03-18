using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PC : MonoBehaviour
{
    public CollectDocuments documentCollector;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && documentCollector.collectedDocument >= documentCollector.requiredDocument)
        {
            
            SceneManager.LoadScene("PC_Screen");
        }
    }

}
