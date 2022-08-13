using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantasmaScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private Animator animator;
    public Rigidbody2D rb;
    public float speed = 5f;
    public GameObject BulletPrefab;
    private float LastShoot;
    private int hp = 7;
    private bool isAlive;
    public GameObject room;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null) return;
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float distanceX = Mathf.Abs(target.transform.position.x - transform.position.x);
        float distanceY = Mathf.Abs(target.transform.position.y - transform.position.y);
        animator.SetBool("lookRight", direction.x > 0.0f );
        animator.SetBool("lookLeft", direction.x < 0.0f && ((angle >= 150f && angle <= 180f) || (angle >= -180f && angle <= -150f)));
        animator.SetBool("lookUp", direction.y > 0.0f && (angle >= 30f && angle <= 150f));

        if (Time.time > LastShoot + 0.25f && (distanceX < 1.0f && distanceY < 1.0f) && isAlive)
        {
            shoot(direction);
            LastShoot = Time.time;
        }
        else
        {
            animator.SetBool("Die", hp == 0);
            
        }


    }

    private void shoot(Vector3 dir)
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position + dir * 0.2f, Quaternion.identity);
        bullet.GetComponent<bulletScript>().setDirection(dir);
    }
    public void hit()
    {
        hp -= 1;
        if (hp == 0)
        {
            isAlive = false;
        }
    }

    public void die()
    {
        room.GetComponent<roomScript>().checkDeaths();
        Destroy(gameObject);
    }
}
