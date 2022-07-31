using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    public bool GameOver = false;
    [SerializeField]
    public bool IsCoop;

 
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (Input.GetKeyDown("r") && GameOver == true)
        {
            


            switch (sceneName)
            {
                case "Single Player":

                    SceneManager.LoadScene("Single Player");
                    break;
                case "Co":
                    SceneManager.LoadScene("Co");
                    break;
            }


        }



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TheMainMenu");
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }



    public void CheckLives()
    {
        
      
            GameOver = true;
        
    }
}
