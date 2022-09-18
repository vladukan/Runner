using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _prefabEnemy;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;
    private float _countTime;
    private void Start()
    {
        Init(_prefabEnemy);
    }
    private void Update()
    {
        _countTime += Time.deltaTime;
        if (_countTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _countTime = 0;
                int numPoint = Random.Range(0, _spawnPoints.Length);
                SetEnemy(enemy, _spawnPoints[numPoint].position);
            }

        }
    }
    private void SetEnemy(GameObject enemy, Vector3 pos)
    {
        enemy.SetActive(true);
        enemy.transform.position = pos;
    }
}
