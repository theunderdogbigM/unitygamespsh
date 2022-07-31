using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybehavior : MonoBehaviour
{
    private Player Player;
   
    [SerializeField]
    private GameObject Laser;
    private Animator GoBoom;
    private int speed = 2;
    private AudioSource audi;
    [SerializeField]
    private AudioClip bang;
    private float firerate;
    private float canfire;
    [SerializeField]
    private AudioClip biu;

    // Start is called before the first frame update
    void Start()
    {
        audi = GetComponent<AudioSource>();
        firerate = Random.Range(2, 3);
        Player = GameObject.Find("Player").GetComponent<Player>();
     
        GoBoom = GetComponent<Animator>();
    }

 

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        

        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
        

            if (player != null)
            {
                player.PLOneDamage();
                
              
            }
            GoBoom.SetTrigger("EnemyBoom");
            speed = 0;
            audi.clip = bang;
            audi.Play(0);
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 1.0f);
        }

       

      

        if (other.tag == "Laser")
        {
           


            Destroy(other.gameObject);

            if (Player != null)
            {
                Player.AddScore(Random.Range(2,20));
            }
           
            GoBoom.SetTrigger("EnemyBoom");
            audi.clip = bang;
            audi.Play(0);
            Destroy(GetComponent<Collider2D>());
            speed = 0;
            Destroy(this.gameObject, 1.0f);
           

        }
        
    }

    private void FireShot()
    {
        audi.clip = biu;
        canfire = Time.time + firerate;

        Instantiate(Laser, new Vector3(transform.position.x, transform.position.y - 1.2f, transform.position.z), Quaternion.identity);
        audi.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > canfire)
        {
            FireShot();
        }
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -3)
        {
            float randomXY = Random.Range(-5f, 5f);
            transform.position = new Vector3(randomXY, 5, 0);
        }
    }
}
