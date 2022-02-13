using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleport : MonoBehaviour
{
    public Vector3 LocalTeleportAT;
    public GameObject TeppichActive;
    public GameObject PlayerFolder;
    public GameObject GameManager;
    public bool NeedTeppich, LocalTeleporterOnly;
    private BoxCollider BoxColliderTrigger;

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
        Eventfinder();
        if (BoxColliderTrigger.tag =="Player")
        {
            



   
        }

        if (LocalTeleporterOnly)
        {
            LocalTeleporter(other.gameObject);
        }
        else
        {
            GameManager.GetComponent<EnumToCords>().ChangeEnumToCords(WohinSollEsGehn.ToString());
            TeleportTo(other.gameObject);
            TeleportAtScene = GameManager.GetComponent<EnumToCords>().TeleportToCord;
        }


    }
    private void TeleportTo(GameObject target)
    {
        GameManager.GetComponent<SceneController>().ChangeScene(WichSceneLoading);
        target.transform.position = TeleportAtScene;


     //   GameManager.GetComponent<EnumToCords>().TeleportToCord;

    }



    private void LocalTeleporter(GameObject target_)
    {
            Debug.Log("Teleport "+target_+" Local:  "+ LocalTeleportAT);
        target_.transform.position = LocalTeleportAT;

    }











    private void Eventfinder()
    {
        PlayerFolder = GameObject.FindGameObjectWithTag("GameController");

        GameManager = GameObject.FindGameObjectWithTag("GameManager");

    }





}


