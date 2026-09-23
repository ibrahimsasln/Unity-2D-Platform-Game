using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] float spawnRate = 5f;
    private void Start()
    {
        InvokeRepeating("SpawnZombie", 5f, spawnRate);
    }
    private void SpawnZombie()
    {
        Instantiate(zombiePrefab, new Vector3(Random.Range(-8f, 8f), 0.5f, 0f), Quaternion.identity);
    }
}
