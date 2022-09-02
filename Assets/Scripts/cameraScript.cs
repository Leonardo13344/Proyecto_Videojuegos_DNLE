using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject currentRoom;
    [SerializeField]
    GameObject player;
    
    public float smoothness;

    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float topLimit;

    public bool change = false;
  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            //Debug.Log("Test Change Room");
            transform.position = new Vector3(currentRoom.transform.position.x, currentRoom.transform.position.y, -10);
            change = false;

        if (currentRoom.name == "Sala1E1")
        {
            changeRoom(-1.17f,1.17f,0f,0f);
        }
        if (currentRoom.name == "Sala2E1")
        {
            changeRoom(-1.17f,1.17f,3.05f,3.05f);
        }
        if (currentRoom.name == "Sala3E1")
        {
            changeRoom(6.61f,8.8f,0f,0f);
        }
        if (currentRoom.name == "Sala4E1")
        {
            changeRoom(-8.8f,-6.6f,0f,0f);
        }
        if (currentRoom.name == "BossRoomE1")
        {
            changeRoom(-16.5f,-14.27f,0f,0f);
        }
    }

    
    public void changeRoom(float leftLimit, float rightLimit, float bottomLimit, float topLimit)
    {
        Debug.Log("Test Change Camera");
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
                transform.position.z
            );
    }


}
