using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    [SerializeField]
    private float speed = 18;
  
    // Start is called before the first frame update
 
 void ShootLaser()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y > 10)
        {
            Destroy(this.gameObject);
        }


        // Update is called once per frame

    }
    // Update is called once per frame
    void Update()
    {
        ShootLaser();
    }
}
