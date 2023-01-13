using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;

    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    public bool characterDied;

    public bool is_Player;

    private HealthUI healthUI;

    // Start is called before the first frame update
    void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();
        //enemyMovement = GetComponentInChildren<EnemyMovement>();
        
        
            healthUI = GetComponent<HealthUI>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //ApplyDemage();
    }
    
    public void ApplyDamage(float damage, bool KnockDown)
    {
        if (characterDied)
        return;

        health -= damage;
        //if (is_Player)
        
         healthUI.DisplayHealth(health);
        
        

        if (health <= 0f)
        {
            animationScript.Death();
            characterDied = true;

            //if is player deactivate enemy script
            if (is_Player)
            {
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;
            }
            return;
        }
        if(!is_Player)
         {
            if(KnockDown)
                {
                    if(Random.Range(0, 2) > 0)
                    {
                        animationScript.KnockDown();
                    }
                }
            else
                {
                    if(Random.Range(0, 3) > 1)
                    {
                        animationScript.Hit();
                    }
                }
            
         }
    }// apply damage

} // class
