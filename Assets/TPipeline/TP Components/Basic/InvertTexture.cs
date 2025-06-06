using UnityEngine;

public class InvertTexture : TerrainPipelineComponent
{
	public override void CreateData(int mapXSize, int mapZSize, float maxMapHeight)
	{
		return;
	}

	public override float[,] ManipulateData(float[,] inData)
	{
		for (int x = 0; x < inData.GetLength(0); x++)
		{
			for (int y = 0;  y < inData.GetLength(1); y++)
			{
				inData[x, y] = 1 - inData[x, y];
			}
		}
		return inData;
	}
}
