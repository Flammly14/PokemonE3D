using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleport : MonoBehaviour
{
    public Vector3 LocalTeleportAT;
    public GameObject TeppichActive;
    public GameObject PlayerFolder;
    public GameObject GameManager;
    public EventSYSUI cih;
    public bool NeedTeppich,InsideHouse, LocalTeleporterOnly,ExitScene;
    private BoxCollider BoxColliderTrigger;
    public string StandortName;


    [Header("Settings für SceneTeleport")]
    public EnumSceneFolder WichSceneLoading;
    public TeleportToVector WohinSollEsGehn;
    public Vector3 TeleportAtScene;
   
    
    private void Awake()
    {

        BoxColliderTrigger = gameObject.GetComponent<BoxCollider>(); //weil OnTriggerEnter nicht tag erkennen kann oder will
      
        if (TeppichActive.gameObject != null)
        {
            TeppichActive.SetActive(NeedTeppich);
        }
  
    }
    

    private void OnTriggerEnter(Collider other)
    {

        cih = GameObject.FindGameObjectWithTag("EventSYS").GetComponent<EventSYSUI>();

        cih.IsInsideBuilding = InsideHouse;
        if (other.gameObject.tag=="Player")
      {
         Eventfinder();

            if (ExitScene)
            {
                Debug.Log("ExitScene("+ (int)WichSceneLoading+")  Was Triggered Teleport.cs:40");
                
                GameManager.GetComponent<SceneController>().UnloadScene(WichSceneLoading);
                LocalTeleporter(other.gameObject);
            }
            else
            {
           if (LocalTeleporterOnly)
           {
            LocalTeleporter(other.gameObject);
          }
          else
          {
            GameManager.GetComponent<EnumToCords>().ChangeEnumToCords(WohinSollEsGehn.ToString());
            TeleportTo(other.gameObject);
           
          }
       


            }
      }

    }
    private void TeleportTo(GameObject target)
    {
        GameManager.GetComponent<SceneController>().ChangeScene(WichSceneLoading);
        GameManager.GetComponent<SceneController>().TeleportDestinationString = StandortName;
        target.transform.position = GameManager.GetComponent<EnumToCords>().TeleportToCord;

    }



    private void LocalTeleporter(GameObject target_)
    {
        GameManager.GetComponent<SceneController>().TeleportDestinationString = StandortName;
        Debug.Log("Teleport "+target_+" Local:  "+ LocalTeleportAT);
        target_.transform.position = LocalTeleportAT;

    }

    private void Eventfinder()
    {
        PlayerFolder = GameObject.FindGameObjectWithTag("GameController");

        GameManager = GameObject.FindGameObjectWithTag("GameManager");

    }

}


