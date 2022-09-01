using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guagua_Script : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    private Animator animator;
    public Rigidbody2D rb;
    public float speed = 4f;
    private int hp = 30;
    private bool isAlive;

    public GameObject room;

    public GameObject bulletPrefab;
    private float lastShoot;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isAlive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.GetComponent<cameraScript>().currentRoom == room)
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
        }

        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        float distanceX = Mathf.Abs(target.transform.position.x - transform.position.x);
        float distanceY = Mathf.Abs(target.transform.position.y - transform.position.y);

        if (direction.x > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        animator.SetBool("run", direction.x != 0.0f && direction.y != 0.0f);
        animator.SetBool("die", hp == 0);

        if (Time.time > lastShoot + 2f && isAlive)
        {
            shoot(direction);
            lastShoot = Time.time;
        }


    }

    private void move()
    {
        if (target == null || !isAlive) return;
        Vector3 pos = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rb.MovePosition(pos);
    }

    private void shoot(Vector3 dir)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + dir * 0.45f, Quaternion.identity);
        bullet.GetComponent<bulletScript>().setDirection(dir);
    }

    private void FixedUpdate()
    {
        move();
    }

    public void hit()
    {
        Debug.Log("Test" + hp);
        if (hp != 0)
        {
            hp -= 1;
            
        }else
        {
            isAlive = false;
        }
    }

    public void die()
    {
        Destroy(gameObject);
        room.GetComponent<roomScript>().muerteEnemigo(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PersonajeMovement pedrito = collision.collider.GetComponent<PersonajeMovement>();
            if (pedrito != null)
            {
                Debug.Log("Test Hit Guagua");
                pedrito.hit();
            }
        }
    }
}
