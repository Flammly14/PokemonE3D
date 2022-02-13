using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookOfSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public bool MenuActive; //ActivateCall to ACtivate Cursor
    public EventSYSUI cih;
    public Canvas GameAddonSettings,ShowTriggerButton;
    public bool DebugOKBool;
    [Header("Bool List")]
    public bool NuzlockeChallenge;
    public bool NoPokeCenter;
    public bool NoMarket;
    public bool NoXP;
    public bool HardcoreMode;
    public bool RandomizerPokemon,RandomizerMovepool,RandomizerPkmnType,RandomizerTeleports;
    public PlayerInput pcontrols;
    private bool PlayerInside;
    public GameObject GlowEffect;
    public GameObject @object;

    


    private void Awake()
    {
        GameAddonSettings.gameObject.SetActive(false);
        ShowTriggerButton.gameObject.SetActive(false);

        pcontrols = new PlayerInput();

        try
        {
            cih = GameObject.FindGameObjectWithTag("EventSYS").GetComponent<EventSYSUI>();
        }
        catch (System.NullReferenceException)
        {
            Debug.Log("No Player Found in Scene");
            cih = null;
           
        }
        


    }

    private void OnEnable()
    {
        pcontrols.Enable();
    }

    private void OnDisable()
    {
        pcontrols.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        ShowTriggerButton.gameObject.SetActive(true);

        for (int i = 0; i < GlowEffect.GetComponent<MeshRenderer>().materials.Length; i++)
        {
            GlowEffect.GetComponent<MeshRenderer>().materials[i].EnableKeyword("BOOLEAN_09370B4F49C14A0E9996235CA1D00488_ON"); //enables keywordbool shader 

            cih.ForceSelectUIElementSYSUI(@object, true);//passed to eventsysui.cs:137
        }
      
        PlayerInside = true;

        //shaderglow start
    }
    private void OnTriggerExit(Collider other)
    {
        cih.ForceSelectUIElementSYSUI(null, false); //passed to eventsysui.cs:137
        ShowTriggerButton.gameObject.SetActive(false);
        GameAddonSettings.gameObject.SetActive(false);
        PlayerInside = false;
        for (int i = 0; i < GlowEffect.GetComponent<MeshRenderer>().materials.Length; i++)
        {
            GlowEffect.GetComponent<MeshRenderer>().materials[i].DisableKeyword("BOOLEAN_09370B4F49C14A0E9996235CA1D00488_ON");//disables keywordbool shader 
            //                                   es muss meshrenderer sein ! material(s) nur wenn es mehr wie 1 material is damit alles läuchtet
        }

        //shaderglow end

    }








    // Update is called once per frame
    void Update()
    {
     
        if (pcontrols.PlayerGround.Interact.triggered == true&& PlayerInside == true) //Menu Active All movement Stop /// something that pkmn BDSP not can do
        {
        
            GameAddonSettings.gameObject.SetActive(true);

            MenuActive = true;
            cih.CallsMenuOpen = MenuActive;

        }
        if (pcontrols.UI.Decline.triggered == true)//Menu Deactive All movment GO   
        {
       
            GameAddonSettings.gameObject.SetActive(false);
            MenuActive = false;
            cih.CallsMenuOpen = MenuActive;
        }
        if (DebugOKBool)
        {
            DebugOK();
        }
       
    }

    private void DebugOK()
    {


    }




    //---------------------------------Trigger

    public void NuzlockeChallengeTrigger(bool triggered)
    {


        NuzlockeChallenge = triggered;
    }
    public void NoPokeCenterTrigger(bool triggered)
    {

        NoPokeCenter = triggered;

    }
    public void NoMarketTrigger(bool triggered)
    {

        NoMarket = triggered;

    }
    public void NoXPTrigger(bool triggered)
    {


        NoXP = triggered;
    }
    public void HardcoreModeTrigger(bool triggered)
    {

        HardcoreMode = triggered;

    }
    public void RandomizerPokemonTrigger(bool triggered)
    {


        RandomizerPokemon = triggered;
    }
    public void RandomizerMovepoolTrigger(bool triggered)
    {
        RandomizerMovepool = triggered;


    }
    public void RandomizerPkmnTypeTrigger(bool triggered)
    {
        RandomizerPkmnType = triggered;


    }
    public void RandomizerTeleportsTrigger(bool triggered)
    {
        RandomizerTeleports = triggered;


    }
    public void ExitButtonTrigger()
    {
        //touch input infos here 

    }



}
