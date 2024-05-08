using Zenject;
using UnityEngine;

public class EnemySpawnerInstaller : MonoInstaller
{
    [SerializeField] EnemySpawnerConfig _enemySpawnerConfig;
    [SerializeField] SpawnPoints _enemySpawnerPointsPrefab;
    public override void InstallBindings()
    {        
        BindConfig();
        BindInstance();        
    }

    private void BindConfig()
    {
        Container.Bind<EnemySpawnerConfig>().FromInstance(_enemySpawnerConfig).AsSingle();
    }

    private void BindInstance()
    {
        SpawnPoints spawner = Container.InstantiatePrefabForComponent<SpawnPoints>(_enemySpawnerPointsPrefab, Vector3.zero, Quaternion.identity, null);
        Container.BindInterfacesAndSelfTo<SpawnPoints>().FromInstance(spawner).AsSingle();

        Container.Bind<EnemyFactory>().AsSingle();

        Container.Bind<EnemySpawner>().AsSingle();
    }
}
