using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private VariableJoystick variableJoystick;
    private CharacterAnimation player_Anim;
    private Rigidbody myBody;
    private Transform groundCheck;

    public float walk_Speed = 3f;
    public float z_Speed = 1.5f;
    public float jumpforce = 4000f;
    private bool jump = false;
    private bool onGround;

    private float rotation_Y = -90f;
    //private float rotation_Speed = 15f;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<CharacterAnimation>();
        groundCheck = gameObject.transform.Find("GroundCheck");
    }
    // Update is called once per frame
    void Update()
    {
        onGround = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        RotatePlayer();
        AnimatePlayerWalk();
        Jump();
    }
    void FixedUpdate()
    {
        DetectMovement();
    }

    /*    void DetectMovement()
        {

            myBody.velocity = new Vector3(
                Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walk_Speed),
                myBody.velocity.y,
                Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-z_Speed));
        } // Detect Movement

        void RotatePlayer()
        {
            if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
            {
                transform.rotation = Quaternion.Euler(0f,rotation_Y, 0f);
            }else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
            {
                transform.rotation = Quaternion.Euler(0f,Mathf.Abs(rotation_Y), 0f);
            }
        } // Rotate Player

        void AnimatePlayerWalk()
        {
            if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0f || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0f)
            {
                player_Anim.Walk(true);
            }
            else
            {
                player_Anim.Walk(false);
            }*/

    //  Movement for the player Mobile UI

    void DetectMovement()
    {

        myBody.velocity = new Vector3(
            variableJoystick.Horizontal * (-walk_Speed),
            myBody.velocity.y,
            variableJoystick.Vertical * (-z_Speed));
    } // Detect Movement

    void RotatePlayer()
    {
        if (variableJoystick.Horizontal  > 0)
        {
            transform.rotation = Quaternion.Euler(0f, rotation_Y, 0f);
        }
        else if (variableJoystick.Horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_Y), 0f);
        }
    } // Rotate Player

    void AnimatePlayerWalk()
    {
        if (variableJoystick.Horizontal != 0f || variableJoystick.Vertical != 0f)
        {
            player_Anim.Walk(true);
        }
        else
        {
            player_Anim.Walk(false);
        }

    }// animate player walk

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            player_Anim.Jump(jump);
            if (jump)
            {
                jump = false;
                myBody.AddForce(Vector3.up * jumpforce);
            }
            jump = false;
        }else
        {
            jump = false;
            player_Anim.Jump(jump);
        }
        
    }
}


