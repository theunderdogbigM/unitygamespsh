using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnmManagerSGPL : MonoBehaviour
{
    //[SerializeField]
    //private GameObject plone;
    //[SerializeField]
    //private GameObject pltwo;
    [SerializeField]
    private GameObject Enemy;

    [SerializeField]
    private GameObject _enemycontainer;

    //[SerializeField]
    //private GameObject asteroid;

    private bool _stopSpawn = false;

    [SerializeField]
    GameObject[] PowerUps;
    // Start is called before the first frame update
    // Start is called before the first frame update


    public void StartSPawn()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowUp());
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //OnPlayerDeath();
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpawn == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(5, -4), 7, 0);
            GameObject newEnemy = Instantiate(Enemy, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemycontainer.transform;
            yield return new WaitForSeconds(5.0f);


        }


    }

    public IEnumerator SpawnPowUp()
    {
        while (_stopSpawn == false)
        {
            int randompow = Random.Range(0, 3);
            float randTime = Random.Range(3.0f, 7.0f);
            Instantiate(PowerUps[randompow], new Vector3(Random.Range(5, -4), 7, 0), Quaternion.identity);

            yield return new WaitForSeconds(randTime);
        }
    }


    public void OnPlayerDeath()
    {
       _stopSpawn = true;

        
    }
}
