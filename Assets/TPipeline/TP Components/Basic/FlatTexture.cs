using UnityEngine;

public class FlatTexture : TerrainPipelineComponent
{
	[Range(0.0f, 1.0f)]
	[SerializeField] float uniformLevel;

	public override void CreateData(int mapXSize, int mapZSize, float maxMapHeight)
	{
		return;
	}

	public override float[,] ManipulateData(float[,] inData)
	{
		for (int x = 0;  x < inData.GetLength(0); x++)
		{
			for (int y = 0; y < inData.GetLength(1); y++)
			{
				inData[x, y] = uniformLevel;
			}
		}
		return inData;
	}
}
