using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roid : MonoBehaviour
{

    [SerializeField]
    private GameObject asteroid;
    private Animator animator;
    private SpawnManager SM;
    private PlayerCOOP Player;
    private PlayerTwo PlayerTwo;
    private AudioSource audios;
    [SerializeField]
    private AudioClip boom;
    // Start is called before the first frame update
    void Start()
    {

        audios = GetComponent<AudioSource>();
        audios.clip = boom;
        animator = GetComponent<Animator>();
        SM = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        Player = GameObject.Find("PlayerOne Variant").GetComponent<PlayerCOOP>();
        PlayerTwo = GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            animator.SetTrigger("Asboom");
            audios.Play(0);
            Destroy(GetComponent<Collider2D>());
            SM.StartSPawn();

            Destroy(this.gameObject, 2.8f);


        }

        if (other.tag == "PlayerOne" )
        {
            animator.SetTrigger("Asboom");
            Player.PLOneDamage();
            audios.Play(0);
            Destroy(GetComponent<Collider2D>());
            SM.StartSPawn();
            Destroy(this.gameObject, 2.8f);
        }
        if (other.tag == "PlayerTwo")
        {
            animator.SetTrigger("Asboom");
            PlayerTwo.PLTwoDamage();
            audios.Play(0);
            Destroy(GetComponent<Collider2D>());
            SM.StartSPawn();
            Destroy(this.gameObject, 2.8f);
        }

    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(new Vector3(0, 0, 4), 2);
    }
}
