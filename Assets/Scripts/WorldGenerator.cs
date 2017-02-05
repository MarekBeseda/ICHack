using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WorldGenerator : MonoBehaviour{
    public GameObject Tree;
    public float Seed;
    public int TreeCount;
    public void GenerateTerrain(TerrainData data)
    {
        float[,,] map = new float[data.alphamapWidth, data.alphamapHeight, 2];
        int count = 0;
        for (int x = 0; x < data.alphamapWidth; x++)
        {
            for (int y = 0; y < data.alphamapHeight; y++)
            {
                float perlin = Mathf.PerlinNoise((float)x / 40 +0.01F + Seed, (float)y / 40 + 0.01F + Seed);
                map[x, y, 0] = perlin;
                map[x, y, 1] = 1 - perlin;
            }
        }
        for (int i = 0; i < TreeCount; i++)
        {
            Instantiate(Tree);
            Vector2 pos = Random.insideUnitCircle.normalized * 300 * Mathf.Pow(Random.value, 1F/3.5F);

            Tree.transform.position = new Vector3(pos.x, 1, pos.y) ;
            count++;
        }
        Debug.Log(count);
        data.SetAlphamaps(0, 0, map);
    }
}
