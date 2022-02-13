
using System.Collections.Generic;
using UnityEngine;


public class MultipleHouseWorker : MonoBehaviour
{

    [Header("Put House HERE")]
    public List<GameObject> Houses;
    public bool DeactiveScript;
    [Header("----------Dont Change READ ONLY---------------")]

    ///buggt gerade etwas rum mit header aber klappt so 
    ///

    [Header(" ")]
    public GameObject GPB;
    public string CurrentElementActive;
    public List<float> DistanceInOrder;
     int SmallestIndex;


    private void Awake() //checkList 
    { 

        GPB = GameObject.FindGameObjectWithTag("Player");
       
        for (int i = 0; i < Houses.Count; i++)
        { DistanceInOrder.Add(i); }
            
    }
    
    void Update()
    {
        if (!DeactiveScript)
        {
            for (int i = 0; i < Houses.Count; i++)
            {

                if (GPB!=null)
                {
                    DistanceInOrder[i] = Vector3.Distance(GPB.transform.position, Houses[i].transform.position);
                }
              
                SmallestIndex = DistanceInOrder.IndexOf(Mathf.Min(DistanceInOrder.ToArray()));
                CurrentElementActive = Houses[SmallestIndex].name;
                if (i != SmallestIndex)
                { Houses[i].gameObject.SetActive(false); }
                else
                { Houses[SmallestIndex].gameObject.SetActive(true); }
            }
       ///     Debug.Log("callmeShit");
        }
        else
        {
            for (int i = 0; i < Houses.Count; i++)
            {
                Houses[i].gameObject.SetActive(true);


            }
        }

    }


}

