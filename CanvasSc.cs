using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class CanvasSc : MonoBehaviour
{
    private int lvone;
    private int lvtwo;
    [SerializeField]
    private Text scoretext;
    //private int addsc = 0;
    [SerializeField]
    private Sprite[] Sprite;
    [SerializeField]
    private Image Im;
    [SerializeField]
    private Image ImTwo;
    [SerializeField]
    private Sprite[] SpriteTwo;
    [SerializeField]
    private Text GameOverT;
    [SerializeField]
    private Text PressR;
    [SerializeField]
    private GameObject PlayerTwo;
    PlayerTwo playertwo;
    PlayerCOOP playerone;
    private int livesone;
    private int livestwo;
    public int addp;
    [SerializeField]
    private GameObject PauseMenu;
    [SerializeField]
    private Animator pausanim;
    


    // Start is called before the first frame update
    void Start()
    {
      
        playertwo = GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>();
        playerone = GameObject.Find("PlayerOne Variant").GetComponent<PlayerCOOP>();
        scoretext.text = "Score: " + addp;
        GameOverT.gameObject.SetActive(false);
        PressR.gameObject.SetActive(false);
        livesone = playerone.lives;
        livestwo = playertwo.lives;
        PauseMenu.SetActive(false);
       
        pausanim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score: " + addp;
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseMenu.SetActive(true);

            pausanim.SetBool("AnimDown", true);
            Time.timeScale = 0.0f;
        }

        LivesGame();
    
       
    }
    public int SwapLives( int currentLivesone)
    {
        Im.sprite = Sprite[currentLivesone];

        livesone = currentLivesone;
     
        return livesone;
    }

    public int SwapLivesTwo(int currentlivestwo)
    {
        ImTwo.sprite = SpriteTwo[currentlivestwo];



        livestwo = currentlivestwo;




        return livestwo;

    }

    public void LivesGame()
    {
        
         lvone = SwapLives(livesone);
        lvtwo = SwapLivesTwo(livestwo);

     


        if (lvone + lvtwo == 0)
        {

            GameOverT.gameObject.SetActive(true);

            StartCoroutine(TextFlick());
            PressR.gameObject.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        
        Time.timeScale = 1.0f;
    }
    public void MainMenu()
    {

        SceneManager.LoadScene("TheMainMenu");
        Time.timeScale = 1.0f;
    }

    IEnumerator TextFlick()
    {
        while (true)
        {
            GameOverT.text = "Game Over";
            yield return new WaitForSeconds(0.5f);
            GameOverT.text = "";
            yield return new WaitForSeconds(0.5f);
        }

    }
  
}
