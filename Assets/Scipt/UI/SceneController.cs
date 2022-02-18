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
    public string TeleportDestinationString = "";
    Image Bar;
    EventSYSUI cih;

    private void Awake()
    {
        instance = this;
        StartScene = SceneManager.GetSceneAt((int)EnumSceneFolder.SceneHandler);
        cih= GameObject.FindGameObjectWithTag("EventSYS").GetComponent<EventSYSUI>();

        if (SceneManager.sceneCount <=1) //wenn zu begin die Anzahl an scenen nicht überschreitet ist das Game im TitleScreen
        {
            SceneManager.LoadSceneAsync((int)EnumSceneFolder.TitleScreen, LoadSceneMode.Additive);
            
       
        }
    }


public void LoadingGame() //muss noch für save data t werden
    {
        LastSceneWasLoaded = SceneManager.GetSceneByBuildIndex((int)EnumSceneFolder.SceneHandler);
        Scene_Loader.Add(SceneManager.UnloadSceneAsync((int)EnumSceneFolder.TitleScreen));
        Scene_Loader.Add(SceneManager.LoadSceneAsync((int)EnumSceneFolder.Overworld, LoadSceneMode.Additive));
        StartCoroutine(ProgressLoader(LastSceneWasLoaded));
        LoadingScreenPref_.SetActive(true);


    }


    public void ChangeScene(EnumSceneFolder @enum) //bekommt infos was geladen werden muss 
    {

            Scene_Loader.Add(SceneManager.LoadSceneAsync((int)@enum, LoadSceneMode.Additive));
        LastSceneWasLoaded = SceneManager.GetSceneByBuildIndex((int)@enum);
        StartCoroutine(ProgressLoader(LastSceneWasLoaded));
        LoadingScreenPref_.SetActive(true);
     
    }


    public void UnloadScene(EnumSceneFolder @enum)
    {
        
        Debug.Log("LastScene ("+(int)@enum+")= "+ SceneManager.GetSceneByBuildIndex((int)@enum).name  + "  Was passed SceneController.cs:48");
         LastSceneWasLoaded = SceneManager.GetSceneByBuildIndex((int)EnumSceneFolder.Overworld);
        Scene_Loader.Add(SceneManager.UnloadSceneAsync((int)@enum));
        StartCoroutine(ProgressLoader(LastSceneWasLoaded));
        LoadingScreenPref_.SetActive(true);
        
    }




    float TotalProgressFloat;
    public IEnumerator ProgressLoader(Scene scene)
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
                cih.CallsMenuOpen = true;
               
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
        cih.CallsMenuOpen = false;

        SceneManager.SetActiveScene(LastSceneWasLoaded);
        LoadingScreenPref_.SetActive(false);
        cih.ShowDestinationUI(TeleportDestinationString);

    }

}
