using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Start is called before the first frame update
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
        if(collision.gameObject.tag == "Enemy")
        {
            caracolScript caracol = collision.collider.GetComponent<caracolScript>();
            fantasmaScript fantasma = collision.collider.GetComponent<fantasmaScript>();
            Guagua_Script guagua = collision.collider.GetComponent<Guagua_Script>();
            Dama_Script dama = collision.collider.GetComponent<Dama_Script>();
            Padre_Script padre = collision.collider.GetComponent<Padre_Script>();
            if (caracol != null)caracol.hit();
            if(fantasma != null)fantasma.hit();
            if (guagua != null)guagua.hit();
            if (dama != null) dama.hit();
            if (padre != null) padre.hit();

            DestroyBullet();
        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Test Player");
            PersonajeMovement pedrito = collision.collider.GetComponent<PersonajeMovement>();
            if (pedrito != null)
            {
                pedrito.hit();
            }
            DestroyBullet();
        }
    }
}
