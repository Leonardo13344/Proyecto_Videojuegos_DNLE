using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject currentRoom;
    private Vector3 ref1;
    public float smoothness;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(transform.position != new Vector3(currentRoom.transform.position.x, currentRoom.transform.position.y, -10))
        {
            transform.position = Vector3.SmoothDamp(transform.position, currentRoom.transform.position, ref ref1, smoothness);
        }*/
        transform.position = new Vector3(currentRoom.transform.position.x, currentRoom.transform.position.y, -10);
    }

    
    
}
