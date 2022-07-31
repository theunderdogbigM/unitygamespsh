using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private float _speed = 5f;
    private float _fireRate= 0.15f;
    private float _canfire = -1f;
    [SerializeField]
    public int lives = 3;
    private SpawnmManagerSGPL spawnmanger;
    [SerializeField]
    private bool trippleshot = false;
    [SerializeField]
    private GameObject TrippleShot;
    [SerializeField]
    private bool sheildOn = false;
    [SerializeField]
    private GameObject SheildVisual;
    [SerializeField]
    private int score = 0;
   
    [SerializeField]
    private LevelManager LM;
    [SerializeField]
    private GameObject righthurt, lefthurt;
    private Animator die;
    private AudioSource laserbiu;
    [SerializeField]
    private AudioClip lasersoundclip, explosion;
    [SerializeField]
    private CanvasSGPL UISGMAN;
  



    public void AddScore(int points)
    {
        score  += points;
      
        UISGMAN.UpdateScore(score);

    }
    // Start is called before the first frame update
    void Start()
    {
        die = GetComponent<Animator>();
        laserbiu = GetComponent<AudioSource>();
        laserbiu.clip = lasersoundclip;
        spawnmanger = GameObject.Find("Spawn_Manager").GetComponent<SpawnmManagerSGPL>();
        lefthurt.SetActive(false);
        righthurt.SetActive(false);
        SheildVisual.SetActive(false); 
      

     

        UISGMAN = GameObject.Find("Canvas").GetComponent<CanvasSGPL>();
    }

    // Update is called once per frame
    void Update()
    {



  CalculateMovementplone();
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canfire)
            {
                SpawnLPlOne();

            }
        

       
        
            void CalculateMovementplone()
            {

            if (Input.GetKey(KeyCode.W))
            {

                transform.Translate(Vector3.up * _speed * Time.deltaTime);


            }
            if (Input.GetKey(KeyCode.S))
            {

                transform.Translate(Vector3.down * _speed * Time.deltaTime);


            }
            if (Input.GetKey(KeyCode.A))
            {

                transform.Translate(Vector3.left * _speed * Time.deltaTime);


            }
            if (Input.GetKey(KeyCode.D))
            {

                transform.Translate(Vector3.right * _speed * Time.deltaTime);


            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.8f, 5.8f), transform.position.y, 0);


            }
        
      
        void SpawnLPlOne()
        {
           
                _canfire = Time.time + _fireRate;

                if (trippleshot == true)
                {
                    Instantiate(TrippleShot, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(laser, new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z), Quaternion.identity);
                }

                laserbiu.Play(0);
            
        }
        
        
    }

   

   
    public void PLOneDamage()
    {
       
            if (sheildOn == true)
            {
                SheildVisual.SetActive(false);
                sheildOn = false;
                return;
            }
            else
            {
                lives -= 1;
                //UIMan.SwapLives(lives);
               UISGMAN.SwapLives(lives);
            }

            if (lives == 2)
            {
                lefthurt.SetActive(true);

            }
            if (lives == 1)
            {
                righthurt.SetActive(true);
            }

        if (lives == 0)
        {
        
            LM.CheckLives();
            _speed = 0;
            die.SetTrigger("deadboom");
        laserbiu.clip = explosion;
        laserbiu.Play(1);
        Destroy(this.gameObject, 0.5f);

            UISGMAN.SaveHighScore(score);
        }

    }



    public void OnTriggerEnter2D(Collider2D other)
    {
       
            if (sheildOn == true && other.tag == "EnemyLaser")
            {
                sheildOn = false;
                SheildVisual.SetActive(false);
                return;
            }
            if (other.tag == "EnemyLaser" && sheildOn == false)
            {
                sheildOn = false;
                PLOneDamage();
            }
        
       
    }

    public void  TrShotIsTrue() {
       
            {
           
                trippleshot = true;

                StartCoroutine(Activate());
            }
        
    }

    public void SpeedUpTrue() {
        
            _speed = 10.0f;
            StartCoroutine(SpeedTime()); 
        
    }

    public void Shieldforone()
    {

        SheildVisual.SetActive(true);

        sheildOn = true;
           
          

        
    }

    public  IEnumerator Activate()
            {
                yield return new WaitForSeconds(5.0f);
                trippleshot = false;

            }
            
     public IEnumerator SpeedTime() {
        yield return new WaitForSeconds(5.0f);
        _speed = 5;
    }



    
   

} 

