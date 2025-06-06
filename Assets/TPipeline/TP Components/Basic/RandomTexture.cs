using UnityEngine;

public class RandomTexture : TerrainPipelineComponent
{
	[Range(0f, 1f)]
	[SerializeField] float scale;

	public override void CreateData(int mapXSize, int mapZSize, float maxMapHeight)
	{
		cashedData = new float[mapXSize, mapZSize];
		for (int x = 0; x < mapXSize; x++)
		{
			for (int z = 0; z < mapZSize; z++)
			{
				cashedData[x, z] = Random.Range(0f, scale);
			}
		}
	}

	public override float[,] ManipulateData(float[,] inData)
	{
		return cashedData;
	}
}
