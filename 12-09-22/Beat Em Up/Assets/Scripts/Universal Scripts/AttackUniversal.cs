using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float attack = 2f;

    private float damage = 2;

    public bool Is_Player, Is_Enemy;

    public GameObject hit_FX_Prefab;

    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }

    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);
        //if (hit.Length == 0) return;

        if (hit.Length > 0)
        {
            
                Vector3 hitFX_Pos = hit[0].transform.position;
                hitFX_Pos.y += 1.3f;
                if (hit[0].transform.forward.x > 0)
                {
                    hitFX_Pos.x += 0.3f;
                }
                else if (hit[0].transform.forward.x < 0)
                {
                    hitFX_Pos.x -= 0.3f;
                }
                GameObject partical = Instantiate(hit_FX_Prefab, hitFX_Pos, Quaternion.identity);
                Destroy(partical, 2f);
            if (Is_Player)
            {
                if (gameObject.CompareTag("ThrowPoint") ||
                    gameObject.CompareTag("LegPoint"))
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                }
                else
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                }
            } // if is player

            if (Is_Enemy)
            {
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
            } // is enemy
        } // hit length greater
        

        gameObject.SetActive(false);
    } // detect collision

} // class
