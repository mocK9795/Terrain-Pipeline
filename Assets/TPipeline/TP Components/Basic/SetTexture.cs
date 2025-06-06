using UnityEngine;

public class SetTexture : TerrainPipelineComponent
{
	[SerializeField] Texture2D _texture;
	public static T[,] ResizeTexture<T>(T[,] textureIn, int sizeX, int sizeZ)
	{
		T[,] resizedTexture = new T[sizeX, sizeZ];

		int width = textureIn.GetLength(0);
		int height = textureIn.GetLength(1);

		for (int y = 0; y < sizeZ; y++)
		{
			for (int x = 0; x < sizeX; x++)
			{
				float xFrac = (float)x / sizeX;
				float yFrac = (float)y / sizeZ;

				int origX = Mathf.RoundToInt(xFrac * width);
				int origY = Mathf.RoundToInt(yFrac * height);
				origX = Mathf.Clamp(origX, 0, width - 1);
				origY = Mathf.Clamp(origY, 0, height - 1);
				resizedTexture[x, y] = textureIn[origX, origY];
			}
		}

		return resizedTexture;
	}

	public static float Value(Color inValue) { return ((inValue.r + inValue.g + inValue.b) / 3) * inValue.a; }

	public static float[,] SampleTexture(Color[,] textureIn)
	{
		int width = textureIn.GetLength(0);
		int height = textureIn.GetLength(1);
		float[,] sampledTexture = new float[width, height];
		for (int x = 0; x < width; x++)
		{
			for (int y =0; y < height; y++)
			{
				sampledTexture[x, y] = Value(textureIn[x, y]);
			}
		}
		return sampledTexture;
	}

	public static Color[,] GetColorData(Texture2D texture)
	{
		if (texture == null)
		{
			Debug.LogError("Map Provided Is Null");
			return null;
		}

		Color[] colorData1D = texture.GetPixels();
		int width = texture.width;
		int height = texture.height;

		Color[,] colorData2D = new Color[width, height];
		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				colorData2D[x, y] = colorData1D[y * width + x];
			}
		}

		return colorData2D;
	}


	public override void CreateData(int mapXSize, int mapZSize, float maxMapHeight)
	{
		cashedData = ResizeTexture(SampleTexture(GetColorData(_texture)), mapXSize, mapZSize);
	}

	public override float[,] ManipulateData(float[,] inData)
	{
		return cashedData;
	}
}
