using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ComboState
{
    NON,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2
}

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation player_Anim;

    private bool activateTimerToReset;

    private float default_Combo_Timer = 0.4f;
    private float current_Combo_Timer;

    private ComboState current_Combo_State;

    [SerializeField]
    private Button_Sprint Punch;
    [SerializeField]
    private Button_Sprint Kick;

    // Start is called before the first frame update
    void Awake()
    {
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }
    void Start()
    {
    
    }
    /*void LateUpdate()
    {
        ComboAttacks();
        ResetComboState();
    }*/
    private void Update()
    {
        ResetComboState();

    }

    public  void ComboAttacks(string Attack)
    {
        //if (Input.GetKeyDown(KeyCode.Z)) Input key for Keyboard
        if (Attack == "Punch")
        {
            if(current_Combo_State == ComboState.PUNCH_3 ||
                current_Combo_State == ComboState.KICK_1 ||
                current_Combo_State == ComboState.KICK_2)
                return;

            current_Combo_State++;
            activateTimerToReset = true;
            Debug.Log("true"+ current_Combo_State);
            current_Combo_Timer = default_Combo_Timer;
            if (current_Combo_State == ComboState.PUNCH_1)
            {
                player_Anim.Punch_1();
            }
            if(current_Combo_State == ComboState.PUNCH_2)
            {
                player_Anim.Punch_2();
            }
            if(current_Combo_State == ComboState.PUNCH_3)
            {
                player_Anim.Punch_3();
            }

            
        } // if Punch Combo

        //if (Input.GetKeyDown(KeyCode.X)) Input key for Keyboard
        if (Attack == "Kick")
        {
            //if combo is Kick 2 or Punch 3 then we have no more combo to perform
            // that is why we exeit from this part of the code
            if (current_Combo_State == ComboState.KICK_2 ||
                current_Combo_State == ComboState.PUNCH_3)
                return;

            //if combo is Nothing(Non) or Punch 1 then or Punch 2 we will
            // perform kick 1 
            if (current_Combo_State == ComboState.NON ||
                current_Combo_State == ComboState.PUNCH_1 ||
                current_Combo_State == ComboState.PUNCH_2)
            {
                current_Combo_State = ComboState.KICK_1;
            }// perform kick 1 

            //4 hit combo
            /*if (current_Combo_State == ComboState.NON ||
                current_Combo_State == ComboState.PUNCH_1 ||
                current_Combo_State == ComboState.PUNCH_2 ||
                current_Combo_State == ComboState.PUNCH_3)
            {
                current_Combo_State = ComboState.KICK_2;
            }*/

            else if (current_Combo_State == ComboState.KICK_1)//if combo is Kick 1 we will increment the value of the current_combo_stat perform kick 1 
            {// move to kick 2
                current_Combo_State++;
            }

            //if combo is Kick 1 we will increment the value of the current_combo_state
            // perform kick 1 
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            //Also checking if combostat is Kick 1 or kick 2 to play its respective animatoins
            if (current_Combo_State == ComboState.KICK_1)
            {
                player_Anim.Kick_1();
            }
            if (current_Combo_State == ComboState.KICK_2)
            {
                player_Anim.Kick_2();
            }

        }// if Kick Combo

    } // combo attacks 

    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            current_Combo_Timer -= Time.deltaTime;
            if (current_Combo_Timer <= 0)
            {
                current_Combo_State = ComboState.NON;

                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }// reset combo state

} // class
