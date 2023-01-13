using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public Text EnemyName;

    [SerializeField]
    private GameObject enemyPrefab;
    public string[] Enames;

    public float xPos;
    public float zPos;
    //public static string[] Anthony { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Start()
    {
        SpawnEnemy();   // This line will spawn new enemy in every new frame Rate 
    }
    public void SpawnEnemy()
    {
        zPos = Random.Range((float)-3.47, (float)-0.48); //s-3.98  e-0.55
        xPos = Random.Range((float)-10.48, (float)10.1);//s10.14  e-10.43
        int No = Random.Range(0, Enames.Length);
        EnemyName.text = Enames[No];
        Instantiate(enemyPrefab, new Vector3(xPos, (float)-0.06,zPos), Quaternion.identity);
    }
}
