using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersonajeMovement : MonoBehaviour
{

    static PersonajeMovement current;

    [Header("BARRA DE VIDA ")]
    [SerializeField] private GameObject barraVida;
    [SerializeField] private Sprite vida1, vida2, vida3, vida0, vida4, vida5, vida6, vida7, vida8, vida9, vida10; 


    [Header("PRUEBA")]
    [SerializeField] private GameObject gameOver;

    [Header("PRUEBA")]
    [SerializeField] private Text contadorScore;
    
    
    [Header("EFECTOS DE SONIDO")]
    [SerializeField] private GameObject ODisparoPlayer;
    [SerializeField] private GameObject OMuertePlayer;
    [SerializeField] private GameObject audioMixer;


    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private float vertical;
    private Animator animator;
    public GameObject BulletPrefab;
    private float LastShoot;
    public float speed;
    private int hp = 10;
    public static bool muerteExterna = false;
    private AudioSource SDisparoPlayer;
    private AudioSource SMuertePlayer;
    private AudioSource SaudioMixer;
    public int score;



    public static void sumarScore(){
        current.score++;
        if(current.score < 10 ) current.contadorScore.text = "0" + current.score;
        else current.contadorScore.text = current.score.ToString();

    }

    public void Awake(){

       if(current != null && current != this){
           //Destroy(gameObject);
           return;
       }
       current = this;
      // DontDestroyOnLoad(gameObject);







   }

    // Start is called before the first frame update
    void Start()
    {



        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        SDisparoPlayer = ODisparoPlayer.GetComponent<AudioSource>();
        SMuertePlayer = OMuertePlayer.GetComponent<AudioSource>();
        SaudioMixer = audioMixer.GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        



        Horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        animator.SetBool("running", Horizontal != 0.0f);
        animator.SetBool("runningDown", vertical < 0.0f);
        animator.SetBool("runningUp", vertical > 0.0f);
        animator.SetBool("Die", hp == 0);

        if(muerteExterna){
            muerteExterna = false;
          

            die();
        }


        //Movimiento
        if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        if (vertical < 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            
        }
        if (vertical > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        
        //Disparos
        if (Input.GetKey(KeyCode.UpArrow) && Time.time > LastShoot + 0.25f)
        {
            shoot(Vector2.up);
            //transform.localScale = new Vector3(1.0f,-1.0f,1.0f);
            LastShoot = Time.time;
            SDisparoPlayer.Play();
        }
        if (Input.GetKey(KeyCode.DownArrow) && Time.time > LastShoot + 0.25f)
        {
            shoot(Vector2.down);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            LastShoot = Time.time;
            SDisparoPlayer.Play();
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Time.time > LastShoot + 0.25f)
        {
            shoot(Vector2.left);
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            LastShoot = Time.time;
            SDisparoPlayer.Play();
        }
        if (Input.GetKey(KeyCode.RightArrow) && Time.time > LastShoot + 0.25f)
        {
            shoot(Vector2.right);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            LastShoot = Time.time;
            SDisparoPlayer.Play();
        }
    }


    private void shoot(Vector3 dir)
    {
        GameObject bullet = Instantiate(BulletPrefab, transform.position + dir * 0.2f, Quaternion.identity);
        bullet.GetComponent<bulletScript>().setDirection(dir);
    }

    private void FixedUpdate(){
        Rigidbody2D.velocity = new Vector2(Horizontal, vertical);   
    }

    public void hit()
    {
        //SMuertePlayer.Play();
        hp -= 1;
        barraDeVida(hp);
    }

    private void barraDeVida(int hp){
        if(hp == 1) barraVida.GetComponent<Image>().sprite = vida1; 
        if(hp == 2) barraVida.GetComponent<Image>().sprite = vida2; 
        if(hp == 3) barraVida.GetComponent<Image>().sprite = vida3; 
        if(hp == 4) barraVida.GetComponent<Image>().sprite = vida4; 
        if(hp == 5) barraVida.GetComponent<Image>().sprite = vida5; 
        if(hp == 6) barraVida.GetComponent<Image>().sprite = vida6; 
        if(hp == 7) barraVida.GetComponent<Image>().sprite = vida7; 
        if(hp == 8) barraVida.GetComponent<Image>().sprite = vida8; 
        if(hp == 9) barraVida.GetComponent<Image>().sprite = vida9; 
        if(hp == 10) barraVida.GetComponent<Image>().sprite = vida10; 

    }


    public void die()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;
        SaudioMixer.Stop();
        Destroy(gameObject);
        barraVida.GetComponent<Image>().sprite = vida0;
         
        SMuertePlayer.Play();
    }
}
