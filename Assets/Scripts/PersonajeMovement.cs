using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private float vertical;
    private float arrowHorizontal;
    private float arrowVertical;
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
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            shoot();
            LastShoot = Time.time;
        }
    }

    
    private void shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f && transform.localScale.y == 1) direction = Vector2.right;
        else if (transform.localScale.x == -1.0f && transform.localScale.y == 1) direction = Vector2.left;
        else if (transform.localScale.y == -1.0f && transform.localScale.x == 1) direction = Vector2.up;
        else if (transform.localScale.y == 1.0f && transform.localScale.x == 1.0f) direction = Vector2.down;
        else direction = Vector2.right;
        
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<bulletScript>().setDirection(direction);
    }

    private void FixedUpdate(){
        Rigidbody2D.velocity = new Vector2(Horizontal, vertical);
    }
}
