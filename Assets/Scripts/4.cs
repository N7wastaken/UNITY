using UnityEngine;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour
{
    [Header("Ustawienia")]
    public GameObject cubePrefab;
    public int cubeCount = 10;
    public float areaSize = 10f;

    private List<Vector3> usedPositions = new List<Vector3>();

    void Start()
    {
        SpawnCubes();
    }

    void SpawnCubes()
    {
        if (cubePrefab == null)
        {
            Debug.LogError("Brak przypisanego prefab'u Cube!");
            return;
        }

        int attempts = 0;
        int spawned = 0;

        while (spawned < cubeCount && attempts < cubeCount * 20)
        {
            attempts++;

            float x = Random.Range(-areaSize / 2f + 0.5f, areaSize / 2f - 0.5f);
            float z = Random.Range(-areaSize / 2f + 0.5f, areaSize / 2f - 0.5f);
            Vector3 pos = new Vector3(x, 0.5f, z);

            bool occupied = false;
            foreach (var usedPos in usedPositions)
            {
                if (Vector3.Distance(usedPos, pos) < 1f)
                {
                    occupied = true;
                    break;
                }
            }

            if (!occupied)
            {
                Instantiate(cubePrefab, pos, Quaternion.identity);
                usedPositions.Add(pos);
                spawned++;
            }
        }

        Debug.Log($"Wygenerowano {spawned} kostek.");
    }
}
