using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int waveNumber;
    public GameObject zombieCounter;

    private bool spawning = true;

    void Start()
    {
        waveNumber = 1;
        StartCoroutine(SpawnWaves());
    }
    void Update ()
    {
        if(!spawning && zombieCounter.transform.childCount == 0)
        {
            StartCoroutine(SpawnWaves());
            spawning = true;
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        
        spawning = true;
        for (int i = 0; i < hazardCount + (waveNumber * 5); i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            GameObject copy = Instantiate(hazard, spawnPosition, spawnRotation);
            copy.transform.parent = zombieCounter.transform;
            yield return new WaitForSeconds(spawnWait);
        }
        spawning = false;
        waveNumber++;
    }
}