using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenWorker : MonoBehaviour
{
    public static TitleScreenWorker instance;
    SceneController S_Cont;

    private void Awake()
    {
        instance = this;
        S_Cont = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SceneController>();
    }




    public void StartGame()
    {
        S_Cont.LoadingGame();
    }
    public void LoadGame()
    {

    }
    public void Settings()
    {

    }
    public void AboutME()
    {

    }
    public void ExitGame()
    {

    }



}
