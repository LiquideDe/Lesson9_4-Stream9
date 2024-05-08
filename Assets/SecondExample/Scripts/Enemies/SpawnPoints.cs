using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] List<Transform> _points;

    public List<Transform> Points => _points;
}
