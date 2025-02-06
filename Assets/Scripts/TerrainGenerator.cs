using UnityEngine;
using UnityEngine.UIElements;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int _depth = 10;

    [SerializeField] private int _width = 256;
    [SerializeField] private int _height = 256;

    [SerializeField] private float _scale = 10;

    private float _offsetX = 100f;
    private float _offsetY = 100f;

    private Terrain _terrain;

    private void Start()
    {
        _offsetX = Random.Range(0f, 9999f);
        _offsetY = Random.Range(0f, 9999f);

        _terrain = GetComponent<Terrain>();
        _terrain.terrainData = GenerateTerrain(_terrain.terrainData);
    }
    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = _width + 1;

        terrainData.size = new Vector3(_width, _depth, _height);

        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[_width, _height];
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = ((float)x + _offsetX) / _width * _scale;
        float yCoord = ((float)y + _offsetY) / _height * _scale;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }

}
