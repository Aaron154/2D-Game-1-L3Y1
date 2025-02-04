using System.Collections;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;

    float spawnInterval = 5f;
    float minimumSpawnInterval = 1f;
    float intervalDecrease = 0.02f;

    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (objectToSpawn != null && spawnPoint != null)
            {
                Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            }
            else
            {
                Debug.LogWarning("Object to spawn or spawn point not set.");
            }

            yield return new WaitForSeconds(spawnInterval);

            spawnInterval = Mathf.Max(minimumSpawnInterval, spawnInterval - intervalDecrease);
        }
      
    }
}
