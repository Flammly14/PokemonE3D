using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMapName : MonoBehaviour
{
    public string Location;


    [Header("+++++++++++ReadOnly++++++++++")]
    public GameObject PlayerFolder;
    public GameObject GameManager;
    public EventSYSUI cih;
    public string LocationBeforThis;

    private void OnTriggerEnter(Collider collision)
    {
        Eventfinder();


        Invoke("test", 0.2f);




    }
    private void test()
    {

        cih.ShowDestinationUI(Location);
        cih.StandortName = Location;


    }

    private void Eventfinder()
    {
        PlayerFolder = GameObject.FindGameObjectWithTag("GameController");
        cih = GameObject.FindGameObjectWithTag("EventSYS").GetComponent<EventSYSUI>();
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        LocationBeforThis= cih.StandortName;
    }


}
