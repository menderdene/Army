using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Enemy;

    public int xPos;

    public int zPos;

    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyDrop());
    }

    IEnumerator enemyDrop()
    {
        while (enemyCount < 100)
        {
            xPos = Random.Range(-45, 45);
            zPos = Random.Range(-45, 45);
            Instantiate(Enemy, new Vector3(xPos, 1.58333f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
            enemyCount += 1;
        }
    }
}
