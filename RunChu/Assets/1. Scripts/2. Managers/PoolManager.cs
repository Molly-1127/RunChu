using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Pool
{
    public EPoolObjectType Type;
    public int Size;
    public GameObject Prefab;
    public Transform ParentTransform;
}

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField] private List<Pool> pools;

    private Dictionary<EPoolObjectType, List<GameObject>> poolDictionary;

    private void Start()
    {
        InitPool();
    }

    /// <summary>
    /// poolDictionary 초기화
    /// </summary>
    private void InitPool()
    {
        poolDictionary = new Dictionary<EPoolObjectType, List<GameObject>>();

        foreach (Pool pool in pools)
        {
            poolDictionary[pool.Type] = new List<GameObject>();
            AddPoolObject(pool.Type);
        }
    }

    /// <summary>
    /// PoolObject 생성 후 딕셔너리에 Add
    /// </summary>
    /// <param name="poolObjectType"></param>
    private void AddPoolObject(EPoolObjectType poolObjectType)
    {
        Pool pool = pools.Find(x => x.Type == poolObjectType);

        for (int i = 0; i < pool.Size; i++)
        {
            GameObject obj = Instantiate(pool.Prefab, pool.ParentTransform);
            obj.SetActive(false);
            poolDictionary[pool.Type].Add(obj);
        }
    }

    /// <summary>
    /// 딕셔너리에서 poolObjectType에 따른 오브젝트 스폰
    /// </summary>
    /// <param name="poolObjectType"></param>
    /// <returns></returns>
    private GameObject SpawnFromPool(EPoolObjectType poolObjectType)
    {
        if (!poolDictionary.ContainsKey(poolObjectType))
            return null;

        GameObject spawnObj = null;

        for (int i = 0; i < poolDictionary[poolObjectType].Count; i++)
        {
            GameObject curObj = poolDictionary[poolObjectType][i];
            if (!curObj.activeSelf)
            {
                spawnObj = curObj;
                break;
            }
            if (i == poolDictionary[poolObjectType].Count - 1)
            {
                AddPoolObject(poolObjectType);
                spawnObj = poolDictionary[poolObjectType][i+1];
            }
        }

        spawnObj.SetActive(true);
        return spawnObj;
    }
}
