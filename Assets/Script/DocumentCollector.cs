using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DocumentCollector : MonoBehaviour
{
    [SerializeField] GameObject Student;
    public bool isCollected;

    private void Update()
    {
        if (isCollected)
        {
            SceneManager.LoadScene("PC_Screen");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
        }
    }
}
