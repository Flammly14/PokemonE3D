using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem; 

/// <summary>
/// Hier werden die Controller detectet und demensprechend werden auch die Button richtig Visuel angezeigt .
/// Ein Bug zurzeit ist immer noch vorhanden und zwar wenn man mehrere controller nach und nach absteckt
/// kann es dazu kommen das er nciht mehr weis welcher Controller benutzt wrid und geht sofort auf Default um.
/// Default ist Pc .
/// Unterstuezt wird gerade nur PS4 Xbox und generic Controller SwitchPro nein
/// </summary>






public class UIButtonShow : MonoBehaviour
{
    public bool DontWantControllerToShow;
    public string CurrentInputModuleActive,CurrentGamepadActive;
    public GameObject[] ButtonTriggger_;
    public List<string> DevicesList;
      public  string[] ObjectIconname;
    public List<Sprite> PC_Button;
    public List<Sprite> Xbox_Button;
    public List<Sprite> PlayStation_Button;
   public InputDevice DeviceListst;
    bool DetectetGamepad;
    public PlayerInput pcontrols;
   public int NoONeCares_COM; //damit ich einfach den befehl for mit nummern ballern kann
   
    void Start()
    {
        NoONeCares_COM = PC_Button.Count + Xbox_Button.Count + PlayStation_Button.Count;
        pcontrols = new PlayerInput();

        InputSystem.FlushDisconnectedDevices(); ///cleart gamecontroller list

     
            StartDeviceDetection();
      



        }

    void GetIconInfo()
    {
        ButtonTriggger_ = GameObject.FindGameObjectsWithTag("ControllerIconVisible"); ///muss in update sein sonst erkennt er prefabs nicht 

        for (int i = 0; i < ButtonTriggger_.Length; i++)
        {
            ObjectIconname[i] = ButtonTriggger_[i].name;
            

            switch (CurrentInputModuleActive)
            {
                case "PC":
                    switch (ObjectIconname[i])
                    {

                        case "ButtonTrigger_Accept":
                            ButtonTriggger_[i].GetComponent<Image>().sprite = PC_Button[1];
                            break;
                        case "ButtonTrigger_Decline":
                            ButtonTriggger_[i].GetComponent<Image>().sprite = PC_Button[2];
                            break;

                        default:
                            //nothing
                            break;
                    } ///PC
                    break;

                case "Xbox":
                    switch (ObjectIconname[i])
                    {

                        case "ButtonTrigger_Accept":
                            ButtonTriggger_[i].GetComponent<Image>().sprite = Xbox_Button[2];
                            break;
                        case "ButtonTrigger_Decline":
                            ButtonTriggger_[i].GetComponent<Image>().sprite = Xbox_Button[1];
                            break;
                        default:
                            //nothing
                            break;
                    } ///Xbox
                    break;

                case "PS4":
                    switch (ObjectIconname[i])
                    {

                        case "ButtonTrigger_Accept":
                            ButtonTriggger_[i].GetComponent<Image>().sprite = PlayStation_Button[2];
                            break;
                        case "ButtonTrigger_Decline":
                            ButtonTriggger_[i].GetComponent<Image>().sprite = PlayStation_Button[1];
                            break;

                        default:
                            //nothing
                            break;
                    } ///PS4
                    break;

                case "Touch":

                    break;
                default:
                    Debug.LogWarning(CurrentInputModuleActive + "  No Input Modul Detectet in UIButtonShow.cs:12");
                    break;
            }


        }
    }


    void StartDeviceDetection()
    {
   
        for (int i = 0; i < InputSystem.devices.Count; i++)//spiel startet und fragt alle controll einheiten ab
        {
            DevicesList.Add(InputSystem.devices[i].displayName);
            DevicesList.Add(Gamepad.all.ToString());
            DevicesList.Remove("UnityEngine.InputSystem.Utilities.ReadOnlyArray`1[[UnityEngine.InputSystem.Gamepad, Unity.InputSystem, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null]]"); ///removed nonsense
        }
   
        if (!DontWantControllerToShow)
        {
            if (DevicesList.Contains("Xbox Controller") || DevicesList.Contains("Wireless Controller") || DevicesList.Contains("XInputControllerWindows"))
            {
                DetectetGamepad = true;
            }
            else
            {
                CurrentInputModuleActive = "PC";
            }

        }
        else
        {
            CurrentInputModuleActive = "PC";
        }



    }

 public   void InputDeviceChanged() //Detect what is using
    {
        InputSystem.onDeviceChange += //kontrolliert wenn ein device Detected wird
       (device, change) =>
       {
           switch (change)
           {
               case InputDeviceChange.Added:
                   Debug.Log("New device added: " + device);
                   DevicesList.Add(device.layout);
                   switch (Gamepad.current.layout)
                   {
                       case "XInputControllerWindows":
                           CurrentInputModuleActive = "Xbox";
                           break;
                       case "DualShock4GamepadHID":
                           CurrentInputModuleActive = "PS4";
                           break;
                       case "SomethingNoIONb": ///nintendo switch was ich noch nciht weis was das heist 
                           CurrentInputModuleActive = "PS4";
                           break;
                   }
                  
                   break;

               case InputDeviceChange.Removed:
                   Debug.Log("Device removed: " + device);
                   CurrentInputModuleActive = "PC";
                   DevicesList.Remove(device.layout);
                   DetectetGamepad = false;
                   break;
               case InputDeviceChange.Disconnected:
                   Debug.Log("Device Disconnected: " + device);
                   CurrentInputModuleActive = "PC";
                   DetectetGamepad = false;
                   DevicesList.Remove(device.layout);
                   break;
           }

       };
      
            if (DetectetGamepad)//wenn von anfang an was detected wird
            {
                switch (Gamepad.current.layout)
                {
                    case "XInputControllerWindows":
                        CurrentInputModuleActive = "Xbox";
                        break;
                    case "DualShock4GamepadHID":
                        CurrentInputModuleActive = "PS4";
                        break;
                    case "SomethingNoIONb": ///nintendo switch was ich noch nciht weis was das heist 
                        CurrentInputModuleActive = "PS4";
                        break;
                }
            }
        
       
  


    }



    // Update is called once per frame
    void FixedUpdate()
    {
        InputDeviceChanged();
        GetIconInfo();

    



    }
}
