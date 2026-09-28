using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] float firstSpawnDelay = 5f;
    [SerializeField] float spawnRate = 5f;
    [SerializeField] float spawnDistance = 5f;
    [SerializeField] float groundSearchHeight = 10f;
    [SerializeField] float spawnHeightOffset = 0.5f;

    Player player;
    LayerMask groundLayer;

    private void Awake()
    {
        groundLayer = LayerMask.GetMask("Ground");
    }

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        player.Died += StopSpawning;
        InvokeRepeating(nameof(SpawnZombie), firstSpawnDelay, spawnRate);
    }

    private void OnDestroy()
    {
        if (player != null)
        {
            player.Died -= StopSpawning;
        }
    }

    private void StopSpawning()
    {
        CancelInvoke(nameof(SpawnZombie));
    }

    private void SpawnZombie()
    {
        float side = Random.value > 0.5f ? 1f : -1f;
        float spawnX = player.transform.position.x + side * spawnDistance;

        if (TryFindGround(spawnX, out Vector2 groundPoint))
        {
            Instantiate(zombiePrefab, groundPoint + Vector2.up * spawnHeightOffset, Quaternion.identity);
        }
    }

    private bool TryFindGround(float x, out Vector2 groundPoint)
    {
        Vector2 origin = new Vector2(x, player.transform.position.y + groundSearchHeight);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, groundSearchHeight * 2f, groundLayer);

        groundPoint = hit.point;
        return hit;
    }
}
