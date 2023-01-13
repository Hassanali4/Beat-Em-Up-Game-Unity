using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject Left_Arm_Attack_Point,/*Left_Arm_ThrowAttack_Point,*/ Right_Arm_Attack_Point,
                      Left_Leg_Attack_Point, Right_Leg_Attack_Point;

    public float Stand_Up_Timer = 2f;
    public Collider _col;

    private CharacterAnimation animationScript;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip whoosh_Sound, fall_Sound, gound_Hit_Sound, dead_Sound;

    private EnemyMovement enemy_Movement;
    private PlayerMovement playerMovement;

    private ShakeCamera shakeCamera;
    private Rigidbody rb;
    //private EnemyManager enemyManager;

    /*void Left_Arm_Throw_Attack_Point_On()
    {
        Left_Arm_Throw_Attack_Point.SetActive(true);
    }*/
    void Awake()
    {
        animationScript = GetComponent<CharacterAnimation>();
        audioSource = GetComponent<AudioSource>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        if (gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemy_Movement = GetComponentInParent<EnemyMovement>();
            rb = GetComponentInParent<Rigidbody>();
        }
        shakeCamera = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();
        _col = GetComponentInParent<CapsuleCollider>();
    }

    void Left_Arm_Attack_Point_On()
    {
        Left_Arm_Attack_Point.SetActive(true);
    }
    void Left_Arm_Attack_Point_Off()
    {
        if (Left_Arm_Attack_Point.activeInHierarchy)
                Left_Arm_Attack_Point.SetActive(false);
    }
    void Right_Arm_Attack_Point_On()
    {
        Right_Arm_Attack_Point.SetActive(true);
    }
    void Right_Arm_Attack_Point_Off()
    {
        if (Right_Arm_Attack_Point.activeInHierarchy)
                Right_Arm_Attack_Point.SetActive(false);
    }
    void Left_Leg_Attack_Point_On()
    {
        Left_Leg_Attack_Point.SetActive(true);
    }
    void Left_leg_Attack_Point_Off()
    {
        if (Left_Leg_Attack_Point.activeInHierarchy)
                Left_Leg_Attack_Point.SetActive(false);
    }
    void Right_Leg_Attack_Point_On()
    {
        Right_Leg_Attack_Point.SetActive(true);
    }
    void Right_leg_Attack_Point_Off()
    {
        if (Right_Leg_Attack_Point.activeInHierarchy)
                Right_Leg_Attack_Point.SetActive(false);
    }
   
    void TagLeft_Arm()
    {
        // Left_Arm_Attack_Point.tag = Tags.LEFT_ARM_TAG;
    }
    void UnTagLeft_Arm()
    {
      //  Left_Arm_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }
    void TagLeft_Leg()
    {
       // Left_Leg_Attack_Point.tag = Tags.LEFT_ARM_TAG;
    }
    void UnTagLeft_Leg()
    {
       // Left_Leg_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }

    void Enemy_StandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }

    IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(Stand_Up_Timer);
        animationScript.StandUp();
    }


    //            Sounds

    public void Attack_FX_Sound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = whoosh_Sound;
        audioSource.Play();
    }
    public void CharacterDiedSound()
    {
        audioSource.volume = 1f;
        audioSource.clip = dead_Sound;
        audioSource.Play();
    }

    public void Enemy_KnockDown()
    {
        audioSource.clip = fall_Sound;
        audioSource.Play();
    }
    public void Enemy_HitGround()
    {
        audioSource.clip = gound_Hit_Sound;
        audioSource.Play();
    }

    public void DisablePlayerMovement()
    {
        playerMovement.enabled = false;
    }

    public void DisableMovement()
    {           

        enemy_Movement.enabled = false;
        _col.enabled = false;

        rb.isKinematic = true;
        //set the layer of the Parent GameObject to 0th layer in the Game Hirarchy
        //so player cannot attak the enemy on the ground


        //set the enemy parent to default layer
        //transform.parent.gameObject.layer = 0;
    }
    public void EnableMovement()
    {

        enemy_Movement.enabled = true;
        _col.enabled = true;
        rb.isKinematic = false;
        //set the layer of the Parent GameObject to 9th layer in the Game Hirarchy
        //so player can attak the enemy when it gets up from the gruond

        //set the enemy parent to default layer
        transform.parent.gameObject.layer = 9;
    }

    public void ShakeCameraOnFall()
    {
        shakeCamera.SouldShake = true;
    }

    public void CharacterDied()
    {
        Invoke("DeactivateGameObject", 2f);
        rb.isKinematic = true;
        
    }
    public void DeactivateGameObject()
    {
        EnemyManager.instance.SpawnEnemy();
        gameObject.SetActive(false);
    }


} // class































































