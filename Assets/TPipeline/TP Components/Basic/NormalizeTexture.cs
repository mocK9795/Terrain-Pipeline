using UnityEngine;

public class NormalizeTexture : TerrainPipelineComponent
{
	public static float[,] NormalizeMap(float[,] noiseMap, float minLocalNoiseHeight, float maxLocalNoiseHeight)
	{
		int width = noiseMap.GetLength(0);
		int height = noiseMap.GetLength(1);

		float[,] normalizedMap = new float[width, height];

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				normalizedMap[x, y] = Mathf.InverseLerp(minLocalNoiseHeight, maxLocalNoiseHeight, noiseMap[x, y]);
			}
		}

		return normalizedMap;
	}

	public static Vector2 GetMapMinMax(float[,] noiseMap)
	{
		int width = noiseMap.GetLength(0);
		int height = noiseMap.GetLength(1);

		float minLocalNoiseHeight = float.MaxValue;
		float maxLocalNoiseHeight = float.MinValue;

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				float noiseHeight = noiseMap[x, y];

				if (noiseHeight < minLocalNoiseHeight)
				{
					minLocalNoiseHeight = noiseHeight;
				}
				if (noiseHeight > maxLocalNoiseHeight)
				{
					maxLocalNoiseHeight = noiseHeight;
				}
			}
		}

		return new(minLocalNoiseHeight, maxLocalNoiseHeight);
	}

	public override void CreateData(int mapXSize, int mapZSize, float maxMapHeight)
	{
		return;
	}

	public override float[,] ManipulateData(float[,] inData)
	{
		var mapMinMax = GetMapMinMax(inData);
		return NormalizeMap(inData, mapMinMax.x, mapMinMax.y);
	}
}
