using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

///Alles was hier drunter ist wird genuzt c# und unity kacekn nur gerade rum 
using TMPro;
using UnityEngine.InputSystem;
using Cinemachine;


public class EventSYSUI : MonoBehaviour
{
    public bool IsInMenu;
    public GameObject OverworldOverlayCanvas;
    public bool ESCMENUACTIVE;
    public bool CallsMenuOpen; //wenn etwas anderes das menü offen haben will
    public PlayerInput pcontrols;
    public GameObject CameraMoveController;
    public Image PokeTechImage;
     Animation PTAnim;
    Vector3 Reffer;
    StartMenu StartMenu;
    CursorIconHandler cih;
    public bool PokeTechEnabled; //wird von poketechcontroller dauerhaft abgefragt
    public bool  PokeTechBig;
    public EventSystem @event;
    // Awake+ Enable +Disable need to be there to work wit new input system

    private void Awake()
    {
        OverworldOverlayCanvas.SetActive(true);
            Reffer = new Vector3(2, 2, 2);
        pcontrols = new PlayerInput();
        PTAnim = PokeTechImage.gameObject.GetComponent<Animation>();
        cih = gameObject.GetComponent<CursorIconHandler>();
        StartMenu = gameObject.GetComponent<StartMenu>();

    }
 
    private void OnEnable()
    {
        pcontrols.Enable();
    }
    private void OnDisable()
    {
        pcontrols.Disable();
    }
    private void FixedUpdate()
    {
        MEnuStuff();
 
    }
    private void Update() 
    {
        ESCMenu(pcontrols.UI.StartMenu.triggered);//new input dont like fixed update ///weil es so in den settings eingestellt ist 
     
        if (!CallsMenuOpen&& ESCMENUACTIVE==false)
        {
            PokeTechActivator();
        }
        
    }
    void PokeTechActivator()
    {
        if (pcontrols.UI.PokeTech.triggered&& ESCMENUACTIVE == false)
        {
            if (PokeTechImage.gameObject.transform.localScale == Reffer)
            {
                PTAnim.Play("GoBigPokeTech");
                pcontrols.PlayerGround.Disable();
                pcontrols.PlayerFly.Disable();

            }
            if (PokeTechImage.gameObject.transform.localScale != Reffer)
            {
                PTAnim.Play("GoSmallPokeTech");
                pcontrols.PlayerGround.Enable(); //not working
                pcontrols.PlayerFly.Enable();
            }
        }
    }
    public void MEnuStuff()
    {
        if (!ESCMENUACTIVE)
        {
            switch (pcontrols.UI.MouseActiveONButton.IsPressed() || CallsMenuOpen) //hier müssen condition für menu open eingetragen werden
            {
                case true:

                    cih.CursorNeedActive();
                    IsInMenu = true;
                    CameraMoveController.GetComponent<CinemachineFreeLook>().gameObject.SetActive(false); //ignorier red shit
   
                    break;

                case false:

                    cih.CursorNeedDeactrive();
                    IsInMenu = false;
         
                    CameraMoveController.GetComponent<CinemachineFreeLook>().gameObject.SetActive(true);//ignorier red shit
   
                    break;
           
            }


        }
    }


    public void ESCMenu(bool pressed)
    {
        if (pressed)
        {



            if (!IsInMenu)
            {
                ESCMENUACTIVE = !ESCMENUACTIVE; //activate and disactivate bool via button
                StartMenu.ActivateStartMenu(ESCMENUACTIVE);
                switch (ESCMENUACTIVE)
                {
                    case true:
                        cih.CursorNeedActive();
                        
                        CameraMoveController.GetComponent<CinemachineFreeLook>().gameObject.SetActive(false);//ignorier red shit
                        break;
                    case false:
                        cih.CursorNeedDeactrive();

                        CameraMoveController.GetComponent<CinemachineFreeLook>().gameObject.SetActive(true);//ignorier red shit
                        break;
                }

            }
        }
    }

    public void ForceSelectUIElementSYSUI(GameObject @object,bool status) /// @object ist für UI select icon sachen damit automatisch was ausgewählt wird
    {
        if (status)
        {
            gameObject.GetComponent<EventSystem>().SetSelectedGameObject(@object);
        }
        else
        {
            gameObject.GetComponent<EventSystem>().SetSelectedGameObject(null);
        }
        

    }


}
