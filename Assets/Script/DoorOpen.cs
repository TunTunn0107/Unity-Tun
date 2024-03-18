using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject key;

    public bool gotKey = false;

    public Transform teleportDestination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(gotKey == true)
        {
            other.transform.position = teleportDestination.position;
        }
        
    }


}
