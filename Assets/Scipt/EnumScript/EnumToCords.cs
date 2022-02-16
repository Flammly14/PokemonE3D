using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumToCords : MonoBehaviour
{
    public string TeleportTo;
    public Vector3 TeleportToCord;
   public void ChangeEnumToCords(string EnumPos)
    {
      
        switch (EnumPos)
        {
            case "PlayerHouseInside" :
                TeleportToCord =new Vector3(3f,-64f,268);
                break;
                   case "RivaleHouseInside":
                TeleportToCord = new Vector3(-25.1060009f, -63.9199982f, 268.200989f);
                break;
            case "ProfHouseInside":
                TeleportToCord = new Vector3(17.0559998f, -68.7900009f, 275.062988f);
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
