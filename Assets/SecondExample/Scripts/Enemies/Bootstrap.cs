using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private EnemySpawner _spawner;

    [Inject]
    private void Construct(EnemySpawner spawner)
    {
        _spawner = spawner;
    }

    private void Awake()
    {
        _spawner.StartWork();
    }
}
