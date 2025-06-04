using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CloneSpawner : MonoBehaviour
{
    [SerializeField] private Clone ZombiePrefab;
    [SerializeField] private Clone Enemy2;
    private Factory<Clone> cloneFactory = new Factory<Clone>();
    [SerializeField] private Transform[] SpawnLocations;

    private void Awake()
    {
        cloneFactory[ZombiePrefab.name] = ZombiePrefab;
        cloneFactory[Enemy2.name] = Enemy2;
    }

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            int rand = Random.Range(0, SpawnLocations.Length);
            if (i % 2 == 0)
            {
                cloneFactory[ZombiePrefab.name].Copy<Zombie>(SpawnLocations[rand]);
            }
            else
            {
                cloneFactory[Enemy2.name].Copy<Zombie>(SpawnLocations[rand]);
            }
        }
    }
}