using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawn : MonoBehaviour
{
    public GameObject ammoCopy;
    public Vector3[] spawnCoords = new Vector3 [6];
    public int ammoCopyCount;
    public float spawnWait;
    public float startWait;
    public int waveNumber;
    public float waveWait;
    public float zombieCounter;

    public GameObject ammoCounter;

    private bool spawning = true;

    void Start()
    {
     
        StartCoroutine(SpawnAmmo());
    }

    void Update()
    {
        waveNumber = FindObjectOfType<GameController>().waveNumber;

        if (!spawning && FindObjectOfType<GameController>().spawning)
        {
            var copies = GameObject.FindGameObjectsWithTag("ammo");
            foreach (var ammoDup in copies)
            {
                Destroy(ammoDup);
            }
            StartCoroutine(SpawnAmmo());
            spawning = true;
        }
    }

    IEnumerator SpawnAmmo()
    {
        yield return new WaitForSeconds(startWait);
        spawning = true;

        for (int i = 0; i < ammoCopyCount + (waveNumber * 3); i++)
        {
            int randomValues = UnityEngine.Random.Range(0, spawnCoords.Length);

            Vector3 spawnPosition = new Vector3(spawnCoords[randomValues].x, spawnCoords[randomValues].y, spawnCoords[randomValues].z);
            Quaternion spawnRotation = Quaternion.identity;
            GameObject copy = Instantiate(ammoCopy, spawnPosition, spawnRotation);
            copy.transform.parent = ammoCounter.transform;
            yield return new WaitForSeconds(spawnWait);

        }

        spawning = false;
    }

}
