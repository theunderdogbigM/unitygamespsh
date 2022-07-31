using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrippleShotPowerUp : MonoBehaviour
{

    [SerializeField]
    private GameObject Player;
    
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private int powerUpID;

    [SerializeField]
    private AudioClip baboom;
   


    // Start is called before the first frame update
    void Start()
    {

       
        Player = GameObject.FindWithTag("Player");
      
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }

        if (Player == null)
        {
            Destroy(this.gameObject);
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
       

            
                if (other.tag == "Player") { 
                     AudioSource.PlayClipAtPoint(baboom, transform.position, 100.0f);
                        switch (powerUpID)
                        {
                            case 0:

                              
                                
                                 Player.GetComponent<Player>().TrShotIsTrue();
                    break;

                            case 1:
                                Player.GetComponent<Player>().SpeedUpTrue();
                  
                                break;
                case 2:
                    Player.GetComponent<Player>().Shieldforone();
                  
                    break;
            }

                        Destroy(this.gameObject);

                }
            

        

       

         

    }
}

   


