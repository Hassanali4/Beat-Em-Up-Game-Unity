using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public Transform mc;//Main Camera
    public float power = 0.2f;
    public float duration = 0.2f;
    public float slowDownAmount = 1f;
    private bool should_Shake;
    private float initialDuration;

    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        mc = Camera.main.transform;
        //startPosition = mc.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        Shake();    
    }

    void Shake()
    {
        if (should_Shake)
        {
            if (duration > 0f)
            {
                //mc.position = startPosition + Random.insideUnitSphere * power;
                mc.position = mc.localPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
                

            }else
            {
                should_Shake = false;
                duration = initialDuration;
                //mc.localPosition = startPosition;
            }

        }// if we should shake the camera
    }

    public bool SouldShake
    {
        get { return should_Shake; }
        set{ should_Shake = value; }
    }
}
