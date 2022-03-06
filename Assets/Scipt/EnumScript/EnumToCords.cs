using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wandelt EnumSceneFolder zu Coordianten um weil ich zu dumm bin es in einer einzigen Enum zu speichern gibt es ein "Switch" dazu
/// </summary>




public class EnumToCords : MonoBehaviour
{
    public string TeleportTo;
    public Vector3 TeleportToCord;
    

   public void ChangeEnumToCords(string EnumPos)
    {
      
        switch (EnumPos)
        {
            case "PlayerHouseInside" :
                TeleportToCord = new Vector3(3.26399994f, -63.9199982f, 267.968994f);


                break;
                   case "RivaleHouseInside":
                TeleportToCord = new Vector3(-25.0809994f, -63.9199982f, 268.057007f);


                break;
            case "ProfHouseInside":
                TeleportToCord = new Vector3(17.0410004f, -68.7809982f, 274.945007f);

                break; 
            case "Overworld":
                TeleportToCord = Vector3.zero;
                break;
     
            case "_____LittlerRoot_______":
                TeleportToCord = Vector3.zero;
                Debug.Log("Error WohinSoll gehn ist falsch eingestellt ");
                break;
            default:
                TeleportToCord = Vector3.zero;
                break;
        }
    }
}
