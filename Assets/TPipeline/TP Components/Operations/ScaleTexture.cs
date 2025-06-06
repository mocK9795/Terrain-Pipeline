using UnityEngine;

public class ScaleTexture : TerrainPipelineComponent
{
	[SerializeField] float scale;

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
				inData[x, y] = inData[x, y] * scale;
			}
		}
		return inData;
	}
}
