using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomScript : MonoBehaviour
{

    public List<GameObject> enemies = new List<GameObject>();
    
    //public bool allDead;

    private bool firstTimeEnter;

    public GameObject[] doors;
    public bool open, openDoors;

    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        openDoors = !doors[0].GetComponent<Door_Script>().isLocked; 

        if(open == false && openDoors == true)
        {
            foreach( GameObject door in doors)
            {
                door.GetComponent<Door_Script>().isLocked = true;
            }
        }
        else if ( open == true && openDoors == false)
        {
            foreach( GameObject door in doors)
            {
                door.GetComponent<Door_Script>().isLocked = false;
            }
        }
        
        if (allDead())
        {
            open = true;
        }
    }

    public bool allDead()
    {
        if(enemies.Count <= 0)
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }

    public void muerteEnemigo(GameObject enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Camera.main.GetComponent<cameraScript>().currentRoom = gameObject;
            Camera.main.GetComponent<cameraScript>().change = true;
            if (firstTimeEnter == false)
            {
                firstTimeEnter = true;
                open = false;
            }
        }
        
    }

    
}
