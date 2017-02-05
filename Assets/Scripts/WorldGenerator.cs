using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class WorldGenerator{
    public static void GenerateTerrain(TerrainData data)
    {
        float[,,] map = new float[data.alphamapWidth, data.alphamapHeight, 2];
        Debug.Log(data.alphamapWidth + " " + data.alphamapHeight);
        for (int x = 0; x < data.alphamapWidth; x++)
        {
            for (int y = 0; y < data.alphamapHeight; y++)
            {
                float perlin = Mathf.PerlinNoise((float)x / 30 +0.01F, (float)y / 30 + 0.01F);
                map[x, y, 0] = perlin;
                map[x, y, 1] = 1 - perlin;
            }
        }
        data.SetAlphamaps(0, 0, map);
    }
}
