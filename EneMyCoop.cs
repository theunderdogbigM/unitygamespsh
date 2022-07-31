using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneMyCoop : MonoBehaviour
{
 
    private PlayerCOOP playerOne;
    private PlayerTwo playerTwo;
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
    private CanvasSc UIStuff;

    // Start is called before the first frame update
    void Start()
    {
        audi = GetComponent<AudioSource>();
        firerate = Random.Range(2, 3);

        //playerOne = GameObject.Find("PlayerOne Variant").GetComponent<PlayerCOOP>();
        //playerTwo = GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>();
        UIStuff = GameObject.Find("Canvas").GetComponent<CanvasSc>();
        GoBoom = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {

        


        if (other.tag == "PlayerOne")
        {

           PlayerCOOP playerone = other.transform.GetComponent<PlayerCOOP>();

            if (playerone != null)
            {

               playerone.PLOneDamage();
             

            }
            GoBoom.SetTrigger("EnemyBoom");
            speed = 0;
            audi.clip = bang;
            audi.Play(0);
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 1.0f);
        }

        if (other.tag == "PlayerTwo")
        {
            PlayerTwo playertwo = other.transform.GetComponent<PlayerTwo>();

            if (playertwo != null)
            {

                playertwo.PLTwoDamage();
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


            UIStuff.addp += 12;


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
