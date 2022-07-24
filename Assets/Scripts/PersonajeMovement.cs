using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private float vertical;
    public GameObject BulletPrefab;
    private float LastShoot;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        if (vertical < 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else if (vertical > 0.0f) transform.localScale = new Vector3(1.0f, -1.0f, 1.0f);
        
        if (Input.GetKey(KeyCode.UpArrow) && Time.time > LastShoot + 0.25f)
        {
            shoot(Vector2.up);
            LastShoot = Time.time;
        }
        if (Input.GetKey(KeyCode.DownArrow) && Time.time > LastShoot + 0.25f)
        {
            shoot(Vector2.down);
            LastShoot = Time.time;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Time.time > LastShoot + 0.25f)
        {
            shoot(Vector2.left);
            LastShoot = Time.time;
        }
        if (Input.GetKey(KeyCode.RightArrow) && Time.time > LastShoot + 0.25f)
        {
            shoot(Vector2.right);
            LastShoot = Time.time;
        }
    }


    private void shoot(Vector3 dir)
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position + dir * 0.1f, Quaternion.identity);
        bullet.GetComponent<bulletScript>().setDirection(dir);
    }

    private void FixedUpdate(){
        Rigidbody2D.velocity = new Vector2(Horizontal, vertical);   
    }
}
