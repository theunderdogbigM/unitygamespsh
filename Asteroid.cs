using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroid;
    private Animator animator;
    private SpawnmManagerSGPL SM;
    private Player Player;
    private AudioSource audios;
    [SerializeField]
    private AudioClip boom;

 void Start()
    {
        audios = GetComponent<AudioSource>();
        audios.clip = boom;
        animator = GetComponent<Animator>();
        SM = GameObject.Find("Spawn_Manager").GetComponent<SpawnmManagerSGPL>();
        Player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    { if ( other.tag == "Laser")
        {
            Destroy(other.gameObject);
            animator.SetTrigger("Asboom");
            audios.Play(0);
            Destroy(GetComponent<Collider2D>());
            SM.StartSPawn();

            Destroy(this.gameObject, 2.8f);
            
           
        }

        if (other.tag == "Player" ) {
            animator.SetTrigger("Asboom");
            Player.PLOneDamage();
            audios.Play(0);
            Destroy(GetComponent<Collider2D>());
            SM.StartSPawn();
            Destroy(this.gameObject, 2.8f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(new Vector3(0,0,4), 2);
    }
}
