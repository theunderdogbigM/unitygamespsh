using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class CanvasSGPL : MonoBehaviour
{

    [SerializeField]
    private Text scoretext;
    private int addsc = 0;
    [SerializeField]
    private Sprite[] Sprite;
    [SerializeField]
    private Image Im;

    [SerializeField]
    private Text GameOverT;
    [SerializeField]
    private Text PressR;
    [SerializeField]
    private GameObject PauseMenu;
    [SerializeField]
    private Animator pausanim;
    private int currentsc;
    [SerializeField]
    private Text Best;
    [SerializeField]
    private int highScore;


    // Start is called before the first frame update
    void Start()
    {

       highScore = PlayerPrefs.GetInt("HighScore", 0);
        Best.text = "High Score : " + highScore;
      

        Player player = GameObject.Find("Player").GetComponent<Player>();
       
        scoretext.text = "Score: " + addsc;
        GameOverT.gameObject.SetActive(false);
        PressR.gameObject.SetActive(false);
        PauseMenu.SetActive(false);
        pausanim.updateMode = AnimatorUpdateMode.UnscaledTime;

    }

    // Update is called once per frame
    void Update()
    {
   
        //PlayerPrefs.SetInt("HighScore: ", best_score);
        //Best.text = "High Score : " + best_score;
        pausanim.updateMode = AnimatorUpdateMode.UnscaledTime;
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseMenu.SetActive(true);

            pausanim.SetBool("AnimDown", true);
            Time.timeScale = 0.0f;
        }
    }

    public void ResumeGame() {
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void MainMenu() {

        SceneManager.LoadScene("TheMainMenu");
        Time.timeScale = 1.0f;
    }

    public void SwapLives(int currentLivesone)
    {
        Im.sprite = Sprite[currentLivesone];
        if(currentLivesone == 0)
        {
            GameOverT.gameObject.SetActive(true);

            StartCoroutine(TextFlick());
            PressR.gameObject.SetActive(true);
        }
        
    }

    public void UpdateScore(int playerscore)
    {
        scoretext.text = "Score :" + playerscore.ToString();
        currentsc = playerscore;
     
        


    }

    public bool SaveHighScore(int newScore)
    {
        bool gotNewHighScore = newScore > highScore;

        if (gotNewHighScore)
        {
            PlayerPrefs.SetInt("HighScore", newScore);
            PlayerPrefs.Save();
        }

        return gotNewHighScore;
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
