using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosCotroller : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("CHOCOLATE");
        if(collision.gameObject.tag == "Player"){
            Debug.Log("CHOCA");
            PersonajeMovement.sumarScore();
            Destroy(gameObject);

        }


    }


}

