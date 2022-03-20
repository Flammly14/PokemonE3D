using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonWildEncounterHandler : MonoBehaviour
{
    public int HowManyEncounter;
    public List<GameObject> PokemonEncounterFile = new List<GameObject>();
    public List<int> PokemonEncounterDropChance = new List<int>();

    public int MoveUntilEncounter;
    public int MoveUntilShiny;
    public bool ShinyCharm,DindFindSomething,PokemonAllowed;



    private void Awake()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        { 
            ShinyMAth();






        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {










        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {


            MoveUntilEncounter = 0;
            MoveUntilShiny = 99999;


        }
   

    }



    void ShinyMAth()
    {
        if (ShinyCharm)
        {
            MoveUntilShiny = Random.Range(0, 2048);
        }
        else
        {
            MoveUntilShiny = Random.Range(0, 4096);
        }

    }

    void EncounterSettingMath()
    {

        MoveUntilEncounter = Random.Range(0, 128);
    }


}
