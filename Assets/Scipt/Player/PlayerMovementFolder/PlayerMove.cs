using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : MonoBehaviour
{
    public PlayerInput pcontrols;
    public Rigidbody rb;
    public float moveSpeed = 2f;
    public float RotSpeed = 2f;
    public int sprint;
    public Vector2 VDirection = Vector2.zero;
     float RotationZ;
    public EventSYSUI cih;

    private Vector2 LookAtPositon; //ReadOnlyValue Mouse/ControllerCamera
    private Transform MC;
    public string Facing;
    public float LookAtFloat;
    public bool CanWeRun;
    

    private void Awake()
    {
     
        MC = Camera.main.transform;
           pcontrols = new PlayerInput(); // Get info from Controll Scheme
        cih = GameObject.FindGameObjectWithTag("EventSYS").GetComponent<EventSYSUI>();

    }

    private void OnEnable()
    {
        pcontrols.Enable();

    }

    private void OnDisable()
    {
        pcontrols.Disable();
    }

     void Update()
    {
        if (cih.IsInMenu == true || cih.ESCMENUACTIVE == true)
        {
            VDirection.Scale(Vector2.zero);
        }
        else
        {
            VDirection = pcontrols.PlayerGround.Movement.ReadValue<Vector2>().normalized;
            LookAtPositon = pcontrols.Mouse.MouseLook.ReadValue<Vector2>();
        }



    }


    private void LookDirectionString()
    {
        switch (LookAtFloat)
        {
            case 1:
                Facing = "Norden"; // obern
                break;
            case 2:
                Facing = "Osten"; //rechts
                break;
            case 3:
                Facing = "Süden";//unten
                break;
            case 4:
                Facing = "Westen";//links
                break;
            default:
                Facing = "Keine bekante Position"; //DEFAUALT
                break;


        }
    } //not active

    private void FixedUpdate()
    {
        LookAtPositon = MC.right.normalized;
        MoveAndRotationPlayer();
     
    }


    private void MoveAndRotationPlayer()
    {
     

        if (VDirection.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(VDirection.x, VDirection.y) * Mathf.Rad2Deg + MC.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(rb.transform.eulerAngles.y, targetAngle, ref RotationZ, RotSpeed);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        
            if (pcontrols.PlayerGround.Sprint.IsPressed()&&CanWeRun==true)

            {
            
                rb.velocity = moveDir.normalized *moveSpeed*sprint;

            }
            else
            {
            rb.velocity = moveDir.normalized*moveSpeed;

            }

            rb.transform.rotation = Quaternion.Euler(0f, angle, 0f);

        }
     
    }

  




}
