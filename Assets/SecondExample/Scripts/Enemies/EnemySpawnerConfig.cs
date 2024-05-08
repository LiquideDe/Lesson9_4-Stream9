using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnerConfig", menuName = "EnemyConfigs/SpawnerConfig")]
public class EnemySpawnerConfig : ScriptableObject
{
    [SerializeField] float spawnCooldown;

    public float SpawnCooldown => spawnCooldown;
}
