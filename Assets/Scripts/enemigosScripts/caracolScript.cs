using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caracolScript : MonoBehaviour
{
    public Transform target;
    private Vector2 movement;
    public Rigidbody2D rb;
    public float speed = 5f;
    



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //float distanceX = Mathf.Abs(pedrito.transform.position.x - transform.position.x);
        //float distanceY = Mathf.Abs(pedrito.transform.position.y - transform.position.y);
        
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        
       
    }

    private void move()
    {
        Vector3 pos = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rb.MovePosition(pos);
    }

    void FixedUpdate()
    {

        move();

    }

    
}
