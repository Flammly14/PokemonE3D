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
    public GameObject LoadingScreenPref_;
    Image Bar;

    private void Awake()
    {
        instance = this;


        if (SceneManager.sceneCount <=1) //wenn zu begin die Anzahl an scenen nicht überschreitet ist das Game im TitleScreen
        {
            SceneManager.LoadSceneAsync((int)EnumSceneFolder.TitleScreen, LoadSceneMode.Additive);
        }
    }


public void LoadingGame() //muss noch für save data t werden
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
