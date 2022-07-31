using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrippleShotCOOP : MonoBehaviour
{
 

    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private int powerUpID;

    [SerializeField]
    private AudioClip baboom;
 
    private GameObject PlayerTwo;
  
    private GameObject playerone;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTwo = GameObject.FindWithTag("PlayerTwo");
        playerone = GameObject.FindWithTag("PlayerOne");
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }

        //if (PlayerCOP ==null & PlayerTwo == null)
        //{
        //    Destroy(this.gameObject);
        //}
    }
    public void OnTriggerEnter2D(Collider2D other)
    {



        if (other.tag == "PlayerOne")
        {
            AudioSource.PlayClipAtPoint(baboom, transform.position, 100.0f);
            switch (powerUpID)
            {
                case 0:

                  

                    playerone.GetComponent<PlayerCOOP>().TrShotIsTrue();
                    break;

                case 1:
                    playerone.GetComponent<PlayerCOOP>().SpeedUpTrue();
                    break;
                case 2:
                
                    playerone.GetComponent<PlayerCOOP>().Shieldforone();
                    break;
            }

            Destroy(this.gameObject);

        }






        if (other.tag == "PlayerTwo")

        {
            AudioSource.PlayClipAtPoint(baboom, transform.position, 100.0f);
            switch (powerUpID)
            {
                case 0:

                    PlayerTwo.GetComponent<PlayerTwo>().TrShotIsTrue();

                    break;

                case 1:
                    PlayerTwo.GetComponent<PlayerTwo>().SpeedUpTrue();
                    break;
                case 2:
                    PlayerTwo.GetComponent<PlayerTwo>().Shield();
                    break;
            }

            Destroy(this.gameObject);




        }

    }
}
