using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomScript : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Awake()
    {
        //cameraScript = cameraObject.GetComponent<cameraScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Camera.main.GetComponent<cameraScript>().currentRoom = gameObject;
        Debug.Log(Camera.main.GetComponent<cameraScript>().currentRoom);
        Debug.Log(gameObject);


    }
}
