using UnityEngine;

public class MultiplyTexture : TerrainPipelineComponent
{
    [SerializeField] TerrainPipelineComponent _multiplyTexture;

	public override void CreateData(int mapXSize, int mapZSize, float maxMapHeight)
	{
		_multiplyTexture.CreateData(mapXSize, mapZSize, maxMapHeight);
	}

	public override float[,] ManipulateData(float[,] inData)
	{
		var data = _multiplyTexture.ManipulateData(inData);
		for (int x = 0;  x < inData.GetLength(0); x++) 
		{
			for (int y = 0; y < inData.GetLength(1); y++)
			{
				inData[x, y] = data[x, y] * inData[x, y];
			}
		}
		return data;
	}
}
