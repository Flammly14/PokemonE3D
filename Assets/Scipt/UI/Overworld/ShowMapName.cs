using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMapName : MonoBehaviour
{
    public string LocationA,LocationB;
    public GameObject SMN_A, SMN_B;


    [Header("+++++++++++ReadOnly++++++++++")]
    public GameObject PlayerFolder;
    public GameObject GameManager;
    public EventSYSUI cih;

    private void OnTriggerEnter(Collider collision)
    {
        Eventfinder();

        if (cih.StandortName == "") //fallback
        {
            cih.ShowDestinationUI(LocationB);
            cih.StandortName = LocationB;
        }

        if (cih.StandortName ==LocationA)
        {
            cih.ShowDestinationUI(LocationB);
            cih.StandortName = LocationB;
        }
        else
        {
            cih.ShowDestinationUI(LocationA);
            cih.StandortName = LocationA;
        }

     


    }

      private void Awake()
    {


#if UNITY_EDITOR
        SMN_A.name = "(A) Current: " + LocationA;
        SMN_B.name = "(B) Current: " + LocationB;



#endif
  
    
    }
    private void Eventfinder()
    {
        PlayerFolder = GameObject.FindGameObjectWithTag("GameController");
        cih = GameObject.FindGameObjectWithTag("EventSYS").GetComponent<EventSYSUI>();
        GameManager = GameObject.FindGameObjectWithTag("GameManager");

    }
   
}
