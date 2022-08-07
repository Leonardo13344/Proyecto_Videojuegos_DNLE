using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyScript : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public float Speed;
    private Vector2 direction;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = direction * Speed;
    }

    public void setDirection(Vector2 dir)
    {
        direction = dir;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Test BES");
            PersonajeMovement caracol = collision.collider.GetComponent<PersonajeMovement>();
            
            if (caracol != null)
            {
                caracol.hit();
            }
            
        }
        

    }
}
