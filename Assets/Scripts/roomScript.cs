using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomScript : MonoBehaviour
{

    public GameObject[] enemies;
    public bool allDead;

    private bool firstTimeEnter;

    public GameObject[] doors;
    public bool open; 

    // Start is called before the first frame update
    void Awake()
    {
        //cameraScript = cameraObject.GetComponent<cameraScript>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (allDead)
        {
            Debug.Log("All Dead Passed");
        }
    }

    public void checkDeaths()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                allDead = false;
            }else
            {
                allDead = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(firstTimeEnter == false)
            {
                firstTimeEnter = true;
            }
        }
        Camera.main.GetComponent<cameraScript>().currentRoom = gameObject;
    }

    
}
