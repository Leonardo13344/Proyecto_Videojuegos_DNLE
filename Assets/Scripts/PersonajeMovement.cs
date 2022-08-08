using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private float vertical;
    private Animator animator;
    public GameObject BulletPrefab;
    private float LastShoot;
    public float speed;
    private int hp = 10;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        animator.SetBool("running", Horizontal != 0.0f);
        animator.SetBool("runningDown", vertical < 0.0f);
        animator.SetBool("runningUp", vertical > 0.0f);

        //Movimiento
        if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        if (vertical < 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            
        }
        if (vertical > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        
        //Disparos
        if (Input.GetKey(KeyCode.UpArrow) && Time.time > LastShoot + 0.25f)
        {
            shoot(Vector2.up);
            //transform.localScale = new Vector3(1.0f,-1.0f,1.0f);
            LastShoot = Time.time;
        }
        if (Input.GetKey(KeyCode.DownArrow) && Time.time > LastShoot + 0.25f)
        {
            shoot(Vector2.down);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            LastShoot = Time.time;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Time.time > LastShoot + 0.25f)
        {
            shoot(Vector2.left);
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            LastShoot = Time.time;
        }
        if (Input.GetKey(KeyCode.RightArrow) && Time.time > LastShoot + 0.25f)
        {
            shoot(Vector2.right);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            LastShoot = Time.time;
        }
    }


    private void shoot(Vector3 dir)
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position + dir * 0.2f, Quaternion.identity);
        bullet.GetComponent<bulletScript>().setDirection(dir);
    }

    private void FixedUpdate(){
        Rigidbody2D.velocity = new Vector2(Horizontal, vertical);   
    }

    public void hit()
    {
        hp -= 1;
        if (hp == 0) Destroy(gameObject);
    }
}
