using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{

   public List<AsyncOperation> Scene_Loader = new List<AsyncOperation>();
    public static SceneController instance;
    Scene LastSceneWasLoaded;
    Scene StartScene;
    public GameObject LoadingScreenPref_;
    Image Bar;

    private void Awake()
    {
        instance = this;
        StartScene = SceneManager.GetSceneAt((int)EnumSceneFolder.SceneHandler);

        if (SceneManager.sceneCount <=1) //wenn zu begin die Anzahl an scenen nicht �berschreitet ist das Game im TitleScreen
        {
            SceneManager.LoadSceneAsync((int)EnumSceneFolder.TitleScreen, LoadSceneMode.Additive);
            
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Debug.Log("Loaded Scene : "+SceneManager.GetAllScenes()[i].name+"   Current Active is : "+SceneManager.GetActiveScene().name);
            }
        }
    }


public void LoadingGame() //muss noch f�r save data t werden
    {
        
        Scene_Loader.Add(SceneManager.UnloadSceneAsync((int)EnumSceneFolder.TitleScreen));
        Scene_Loader.Add(SceneManager.LoadSceneAsync((int)EnumSceneFolder.Overworld, LoadSceneMode.Additive));
        StartCoroutine(ProgressLoader());
        LoadingScreenPref_.SetActive(true);


    }


    public void ChangeScene(EnumSceneFolder @enum) //bekommt infos was geladen werden muss 
    {
        LastSceneWasLoaded = SceneManager.GetSceneByBuildIndex((int)@enum);

            Scene_Loader.Add(SceneManager.LoadSceneAsync((int)@enum, LoadSceneMode.Additive));

            StartCoroutine(ProgressLoader());
            LoadingScreenPref_.SetActive(true);
    

        

       

   

    }
    public void UnloadToManyScene()
    {
     

    }




    float TotalProgressFloat;
    public IEnumerator ProgressLoader()
    {
        
        for (int i = 0; i < Scene_Loader.Count; i++)
        {
            while (!Scene_Loader[i].isDone) ///wartet bis alles geladen ist
            {
                foreach (AsyncOperation operation in Scene_Loader)
                {
                    TotalProgressFloat += operation.progress;
                }

                TotalProgressFloat = (TotalProgressFloat / Scene_Loader.Count) * 100f;
               
                try
                {
                    Bar = GameObject.Find("Progressbar/LoadinfBar").GetComponent<Image>();
                    Bar.fillAmount = Mathf.RoundToInt(TotalProgressFloat);
                }
                catch (System.NullReferenceException)
                {

                    Bar = null;
                }
           
               
                
                yield return null;
            }
        }




        LoadingScreenPref_.SetActive(false);

    }

}
