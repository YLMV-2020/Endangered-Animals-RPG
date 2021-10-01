using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance;

    public List<GameObject> enemys = new List<GameObject>();

    public List<Vector3> initialPosition = new List<Vector3>();
    public List<Vector3> initialRotation = new List<Vector3>();

    public List<Vector3> positionPlayer = new List<Vector3>();

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].GetComponent<EnemyFollow>().enabled = false;
            initialPosition.Add(enemys[i].transform.position);
            initialRotation.Add(enemys[i].transform.eulerAngles);
        }
    }

    void Update()
    {

    }

    public int indexShop(int indexCage)
    {
        if (indexCage >= 0 && indexCage < 6) return 0;
        else if (indexCage >= 6 && indexCage < 10) return 1;
        else if (indexCage >= 10 && indexCage < 16) return 2;

        return -1;
    }

    public void enableEnemy(int id)
    {
        enemys[id].GetComponent<EnemyFollow>().enabled = true; 
         enemys[id].GetComponentInChildren<Animator>().SetBool("isIdle", false);
    }

    public void disableEnemies()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            enemys[i].GetComponent<EnemyFollow>().enabled = false;
            enemys[i].transform.position = initialPosition[i];
            enemys[i].transform.eulerAngles = initialRotation[i];
            enemys[i].GetComponentInChildren<Animator>().SetBool("isIdle", true);
        }
    }
}
