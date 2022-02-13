using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PokeTechController : MonoBehaviour
{
    public int CurrentPokeTechTab;
    public GameObject CanvasPTech;
    public ArrayList ArrayListPokeTech;
    public GameObject[] GameObjectsPokeTech;
    public TextMeshProUGUI ClockText,DateText;
    public EventSYSUI cih;

    //https://www.imore.com/pokemon-brilliant-diamond-and-shining-pearl-all-poketch-apps-and-locations //All infos about Ptech
    //Font:https://fontesk.com/xenon256-font/
    private void Start()
    {
        cih = GameObject.FindGameObjectWithTag("EventSYS").GetComponent<EventSYSUI>();
    }

    private void FixedUpdate()
    {
        ToggleVisible(cih.PokeTechEnabled);
    }

    public void PokeTechCounterPlusOne() /// poketech button  tab changer
    {
        CurrentPokeTechTab = CurrentPokeTechTab + 1;

        if(CurrentPokeTechTab > GameObjectsPokeTech.Length)
        {
            CurrentPokeTechTab = 0;
        }
    }
    public void ToggleVisible(bool status)
    {
        /*
        switch (true)
        {
            case true:
                CanvasPTech.SetActive(true);
               
                break;
            case false:
  
                CanvasPTech.SetActive(false);
                break;
        }
        */
    }



    // Update is called once per frame
    void Update()
    {
        
        switch (CurrentPokeTechTab)
        {
            default:
                PokeTechAddon_Clock(); /// wen sonst nix active ist 
                break;

            case 0:
                PokeTechAddon_Clock();
                break;
            case 1:
                PokeTechAddon_HiddenMove();
            break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            case 6:

                break;
            case 7:

                break;
            case 8:

                break;
            case 9:

                break;



        }


    }



    void PokeTechAddon_Clock()
    {

        ClockText.text = DateTime.UtcNow.ToString("HH:mm");
        DateText.text = DateTime.UtcNow.ToString("dd/MM/yyyy");
    }
    void PokeTechAddon_HiddenMove()
    {

    }



}
