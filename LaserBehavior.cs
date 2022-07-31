using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed = 18;
    
    // Start is called before the first frame update
    void Start()
    {
    

    }

    void ShootLaser()
    {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (transform.position.y > 10)
            {
                if (transform.parent != null)
                {
                    Destroy(transform.parent.gameObject);
                }
                Destroy(this.gameObject);

            }
       

        // Update is called once per frame
       
    }
    void Update()
    {
        ShootLaser();
    }
}
