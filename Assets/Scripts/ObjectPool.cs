using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    private List<GameObject> _pool = new List<GameObject>();
    protected void Init(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }
    protected void Init(GameObject[] prefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int num = Random.Range(0, prefabs.Length);
            GameObject spawned = Instantiate(prefabs[num], _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }
    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }
}
