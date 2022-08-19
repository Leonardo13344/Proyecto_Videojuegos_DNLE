using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;

   public void PantallaCompleta(bool pantallaCompleta){
        Debug.Log("Grande....");
        Screen.fullScreen = pantallaCompleta;
   }

   public void CambiarVolumen(float volumen){

        audioMixer.SetFloat("VOLUMEN", volumen);
   }

   public void CambiarCalidad(int index){
    QualitySettings.SetQualityLevel(index);
   }
}