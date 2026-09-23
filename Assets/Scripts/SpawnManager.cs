using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] float spawnRate = 5f;
    [SerializeField] float spawnDistance = 5f;
    Player player;
    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        InvokeRepeating(nameof(SpawnZombie), 5f, spawnRate);
    }
    private void SpawnZombie()
    {
        float direction = Random.value > 0.5f ? 1f : -1f;
        float positionX = player.transform.position.x + (direction * spawnDistance);
        Instantiate(zombiePrefab, new Vector3(positionX, 0.5f, 0f), Quaternion.identity);
    }
}
