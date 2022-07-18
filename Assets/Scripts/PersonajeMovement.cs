using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private float vertical;
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
    }

    private void FixedUpdate(){
        Rigidbody2D.velocity = new Vector2(Horizontal, vertical);
    }
}
