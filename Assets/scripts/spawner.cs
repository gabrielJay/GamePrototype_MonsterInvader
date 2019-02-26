using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject spawn;
    //public bool stopSpawning = false;
    //public float spawnTime;
    //public float spawnDelay;

    public Vector3 spawnValues;
    public int hazardCount = 10;
    public float spawnWait =2;
    public float startWait = 2;
    public float waveWait = 2;
    [SerializeField]
    public int waives;
    private int currentwaive = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
//        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (currentwaive<waives)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(spawn, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            currentwaive++;

        }
    }
/*    public void SpawnObject()
    {
        Instantiate(spawn, transform.position, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
    */
}
