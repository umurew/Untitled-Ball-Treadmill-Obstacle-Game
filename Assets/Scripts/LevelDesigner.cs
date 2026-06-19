using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    [SerializeField] private List<GameObject> ObstaclePrefabVariations;
    [SerializeField] private GameObject ObstaclesParent;

    private Vector3 GetRandomPosition(float MinimumX, float MaximumX, float MinimumY, float MaximumY)
    {
        float RandomX = Random.Range(MinimumX, MaximumX);
        float RandomY = Random.Range(MinimumY, MaximumY);

        return new Vector3(RandomX, 5, RandomY);
    }

    public void SpawnRandomObstacle()
    {
        if (ObstaclePrefabVariations.Count == 0)
            return;

        int RandomIndex = Random.Range(0, ObstaclePrefabVariations.Count);
        GameObject SelectedPrefab = ObstaclePrefabVariations[RandomIndex];

        GameObject PrefabInstance = Instantiate(SelectedPrefab, GetRandomPosition(-6f, 6f, -30f, 30f), Quaternion.identity);
        PrefabInstance.transform.SetParent(ObstaclesParent.transform);

        float RandomX = Random.Range(1, 4);
        float RandomY = Random.Range(1, 4);
        float RandomZ = Random.Range(1, 4);
        PrefabInstance.transform.localScale = new Vector3(RandomX, RandomY, RandomZ);

        PrefabInstance.layer = LayerMask.NameToLayer("Obstacles");
    }

    private void Start()
    {
        for (int i = 0; i < 15; i++)
            SpawnRandomObstacle();
    }
}