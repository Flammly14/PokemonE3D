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
                TeleportToCord =new Vector3(4.4f, -0.3f, 268.82f);
  
                break;
                   case "RivaleHouseInside":
                TeleportToCord = new Vector3(-23.96f, -63.9199982f, 268.8f);
        
                break;
            case "ProfHouseInside":
                TeleportToCord = new Vector3(-23.9599991f, -0.300000012f, 268.799988f);

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
