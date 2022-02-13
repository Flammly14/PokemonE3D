using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorIconHandler : MonoBehaviour
{
    
    public PlayerInput pcontrols;
    
    public Texture2D cursorTexture;
    public Texture2D cursorTextureHighlight;
    public Texture2D cursorTextureClick;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    public bool NoMouseNeeded;
   

    private void Awake()
    {
        pcontrols = new PlayerInput();
      
    }

    private void Update()
    {
        if (NoMouseNeeded)
        {
            Cursor.visible = false;
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


    void OnMouseEnter() //in window MouseIconActive
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);

    }

    private void OnMouseDown() //click on it 
    {
        
             Cursor.SetCursor(cursorTextureClick, hotSpot, cursorMode);

    }

    private void OnMouseOver() //Hoverd over something
    {
        Cursor.SetCursor(cursorTextureHighlight, hotSpot, cursorMode);
    }
    void OnMouseExit() // no Window active with mouse 
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }



        public void CursorNeedActive()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
      
        }
    public void CursorNeedDeactrive()
    {
   
       Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Cursor.SetCursor(null, Vector2.zero, cursorMode);// removed icon from cursor
     
        
        }


 
}
