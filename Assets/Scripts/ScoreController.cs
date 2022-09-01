using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    [SerializeField] static int score = 0;
    [SerializeField] static Text scoreTxt;
    
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void aumentoConstante()
    {
        score += 1;
        
    }

    public static void aumentoCaracol()
    {
        score += 2;
        scoreTxt.text = score.ToString();
    }

    public static void aumentoFantasma()
    {
        score += 5;
        scoreTxt.text = score.ToString();
    }

    public static void aumentoBosses()
    {
        score += 10;
        scoreTxt.text = score.ToString();
    }
}
