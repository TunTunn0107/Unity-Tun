using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lock_notification : MonoBehaviour
{
    public TextMeshProUGUI Notification;
    public bool isNotified;

    // Start is called before the first frame update
    void Start()
    {
        isNotified = false;
        Notification.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") &&(.HasKey))
        {
            Notification.gameObject.SetActive(true);
            isNotified=true;
        }

        else
        {
            Notification.gameObject.SetActive(false)
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Notification.gameObject.SetActive(false);
            isNotified = false;
        }
    }
}
