using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caracolScript : MonoBehaviour
{
    public Transform target;
    private Animator animator;
    public Rigidbody2D rb;
    public float speed = 5f;
    private int hp = 8;
    



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

        if (target == null) return;
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);

        animator.SetBool("runRigth", direction.x != 0.0f );
        animator.SetBool("runUp", direction.y > 0.0f && (angle >= 30f && angle <= 150f));
        //Debug.Log("X: " + direction.x);
        animator.SetBool("runDown", direction.y < 0.0f && (angle >= -150 && angle <= -30f));

        if (direction.x > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        



    }
    private void move()
    {
        if (target == null) return;
        Vector3 pos = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rb.MovePosition(pos);
    }
    void FixedUpdate()
    {
        move();
    }

    public void hit()
    {
        hp -= 1;
        if (hp == 0) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PersonajeMovement pedrito = collision.collider.GetComponent<PersonajeMovement>();
            if (pedrito != null)
            {
                Debug.Log("Test Hit Caracol");
                pedrito.hit();
            }
        }
    }


}
