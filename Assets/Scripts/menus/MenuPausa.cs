using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class MenuPausa : MonoBehaviour
{

    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private AudioMixer audioMixer;

    [Header("PRUEBA")]
    [SerializeField] private GameObject gameOver;

   public void Pausa(){
    Time.timeScale = 0f;
    botonPausa.SetActive(false);
    menuPausa.SetActive(true);
   }

   public void Renaudar(){
    Time.timeScale = 1f;
    botonPausa.SetActive(true);
    menuPausa.SetActive(false);
   }

   public void Reiniciar(){
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    gameOver.SetActive(false);
   }
   public void Cerrar(){
    Debug.Log("Salir....");
    Application.Quit();
   }

   public void Regresar(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

   }
    public void VolverAlMenu(){
            SceneManager.LoadScene("MENU 2");

   }
      public void CambiarVolumen(float volumen){

        audioMixer.SetFloat("VOLUMEN", volumen);
   }


}
