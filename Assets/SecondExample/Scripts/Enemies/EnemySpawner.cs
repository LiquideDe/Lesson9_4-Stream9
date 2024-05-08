using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemySpawner
{
    private const string ConfigsPath = "Enemies";

    private const string ConfigName = "EnemySpawnerConfig";

    private float _spawnCooldown;
    private List<Transform> _spawnPoints;
    private MonoBehaviour _monoBehaviour;
    private EnemyFactory _enemyFactory;

    private Coroutine _spawn;

    public EnemySpawner(SpawnPoints spawnPoints, EnemyFactory enemyFactory)
    {
        EnemySpawnerConfig enemySpawnerConfig = Resources.Load<EnemySpawnerConfig>(Path.Combine(ConfigsPath, ConfigName));
        _spawnCooldown = enemySpawnerConfig.SpawnCooldown;
        _spawnPoints = new List<Transform>(spawnPoints.Points);
        _monoBehaviour = spawnPoints;
        _enemyFactory = enemyFactory;
    }

    public void StartWork()
    {
        StopWork();

        _spawn = _monoBehaviour.StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_spawn != null)
            _monoBehaviour.StopCoroutine(_spawn);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
            yield return new WaitForSeconds(_spawnCooldown);
        }
    }
}
