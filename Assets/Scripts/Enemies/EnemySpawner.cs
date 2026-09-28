using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] float firstSpawnDelay = 5f;
    [SerializeField] float spawnRate = 5f;
    [SerializeField] float spawnDistance = 5f;
    [SerializeField] float groundSearchHeight = 10f;
    [SerializeField] float spawnHeightOffset = 0.5f;

    Transform playerTransform;
    Health playerHealth;
    LayerMask groundLayer;

    private void Awake()
    {
        groundLayer = LayerMask.GetMask("Ground");

        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
        playerHealth = player.GetComponent<Health>();
    }

    private void OnEnable()
    {
        playerHealth.Died += StopSpawning;
    }

    private void OnDisable()
    {
        playerHealth.Died -= StopSpawning;
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnZombie), firstSpawnDelay, spawnRate);
    }

    private void StopSpawning()
    {
        CancelInvoke(nameof(SpawnZombie));
    }

    private void SpawnZombie()
    {
        float side = Random.value > 0.5f ? 1f : -1f;
        float spawnX = playerTransform.position.x + side * spawnDistance;

        if (TryFindGround(spawnX, out Vector2 groundPoint))
        {
            Instantiate(zombiePrefab, groundPoint + Vector2.up * spawnHeightOffset, Quaternion.identity);
        }
    }

    private bool TryFindGround(float x, out Vector2 groundPoint)
    {
        Vector2 origin = new Vector2(x, playerTransform.position.y + groundSearchHeight);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, groundSearchHeight * 2f, groundLayer);

        groundPoint = hit.point;
        return hit;
    }
}
