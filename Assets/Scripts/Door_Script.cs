using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Script : MonoBehaviour
{
    public Sprite locked, unlocked;
    public bool isLocked;
    public BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(isLocked == true)
        {
            GetComponent<SpriteRenderer>().sprite = locked;
            collider.enabled = true;
        }
        else if (isLocked == false)
        {
            GetComponent<SpriteRenderer>().sprite = unlocked;
            collider.enabled = false;
        }
        
    }
}
