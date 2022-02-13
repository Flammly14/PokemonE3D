using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartMenu : MonoBehaviour
{
    EventSYSUI SYSUI;
    UIButtonShow IButtonShow;
    public GameObject StartMenuCanvas;
    public GameObject EventSYSSelectUIEvent;


    // Start is called before the first frame update
    void Awake()
    {
        StartMenuCanvas.gameObject.SetActive(false);
           SYSUI = gameObject.GetComponent<EventSYSUI>();
        IButtonShow= gameObject.GetComponent<UIButtonShow>();



        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SYSUI.pcontrols.UI.Decline.triggered == true)  // beim drücken vom ESC button
        {

        }
    }




    public void ActivateStartMenu(bool status)
    {
        
    
        StartMenuCanvas.gameObject.SetActive(status);
        if (status)
        {
            SYSUI.ForceSelectUIElementSYSUI(EventSYSSelectUIEvent, status); //passed game object mit bool status an eventsysui.cs:137
        }
        else
        {
            SYSUI.ForceSelectUIElementSYSUI(null, status);
        }
       



    }


}
