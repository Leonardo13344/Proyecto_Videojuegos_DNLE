using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caracolScript : MonoBehaviour
{
    public Transform target;
    private Animator animator;
    public Rigidbody2D rb;
    public float speed = 5f;
    



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //float distanceX = Mathf.Abs(pedrito.transform.position.x - transform.position.x);
        //float distanceY = Mathf.Abs(pedrito.transform.position.y - transform.position.y);
        
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Debug.Log(angle);

        animator.SetBool("runRigth", direction.x != 0.0f );
        animator.SetBool("runUp", direction.y > 0.0f && (angle >= 30f && angle <= 150f));
        Debug.Log("X: " + direction.x);
        animator.SetBool("runDown", direction.y < 0.0f && (angle >= -150 && angle <= -30f));

        if (direction.x < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            Debug.Log("Test");
        }
        if (direction.x > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        if (direction.y < 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        }
        if (direction.y > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }



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
