using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMCtrl : MonoBehaviour
{
    public bool CoopOn;

    private void Start()
    {
        //    LM = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        //    if (LM == null) { Debug.LogError("LM is Null"); }
    }
    public void LoadSceneSinglePlayer()
    {
        //COOPT();

        SceneManager.LoadScene("Single Player");
      

    }
    public void LoadSceneCoOp()
    {
        //COOPT();

        SceneManager.LoadScene("Co");
     
    }
}
//    public void COOPF()
//    {
//        LM.IsCoop = false;
//    }
//    public void COOPT()
//    {
//        LM.IsCoop = true;
//    }
//}
