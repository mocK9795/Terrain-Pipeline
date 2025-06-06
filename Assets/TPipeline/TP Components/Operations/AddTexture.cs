using UnityEngine;

public class AddTexture : TerrainPipelineComponent
{
	[SerializeField] TerrainPipelineComponent _texture;

	public override void CreateData(int mapXSize, int mapZSize, float maxMapHeight)
	{
		_texture.CreateData(mapXSize, mapZSize, maxMapHeight);
	}

	public override float[,] ManipulateData(float[,] inData)
	{
		var textureData = _texture.ManipulateData(inData);
		for (int x = 0; x < inData.GetLength(0); x++)
		{
			for (int y = 0; y < inData.GetLength(1); y++)
			{
				inData[x, y] += textureData[x, y];
			}
		}
		return inData;
	}
}
