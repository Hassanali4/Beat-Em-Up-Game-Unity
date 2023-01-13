using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Image health_UI;

    [SerializeField]
    private bool Is_Enemy, Is_Player;

    // Start is called before the first frame update
    void Awake()
    {
        if (Is_Enemy)
        {
            health_UI = GameObject.FindWithTag(Tags.Enemy_HEALTH_UI).GetComponent<Image>();
        }
        if (Is_Player)
        {
            health_UI = GameObject.FindWithTag(Tags.HEALTH_UI).GetComponent<Image>();
        }
    }
    public void DisplayHealth(float value)
    {
        value /= 100f;

        if (value < 0f)
            value = 0f;

        health_UI.fillAmount = value;
    } // Display Health
}
