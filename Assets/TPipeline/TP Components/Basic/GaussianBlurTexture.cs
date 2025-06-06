using UnityEngine;

public class GaussianBlurTexture : TerrainPipelineComponent
{
	[SerializeField] int kernelSize;
	[SerializeField] float sigma;

	public float[,] ApplyGaussianBlur(float[,] array)
	{
		int rows = array.GetLength(0);
		int cols = array.GetLength(1);
		float[,] result = new float[rows, cols];

		// Create Gaussian kernel
		float[,] kernel = CreateGaussianKernel(kernelSize, sigma);

		int offset = kernelSize / 2;

		// Iterate over the array
		for (int i = offset; i < rows - offset; i++)
		{
			for (int j = offset; j < cols - offset; j++)
			{
				float sum = 0;
				float weightSum = 0;

				// Apply the kernel
				for (int k = -offset; k <= offset; k++)
				{
					for (int l = -offset; l <= offset; l++)
					{
						sum += array[i + k, j + l] * kernel[k + offset, l + offset];
						weightSum += kernel[k + offset, l + offset];
					}
				}

				result[i, j] = sum / weightSum; // Normalize
			}
		}

		return result;
	}

	public override void CreateData(int mapXSize, int mapZSize, float maxMapHeight)
	{

	}

	public override float[,] ManipulateData(float[,] inData)
	{
		return ApplyGaussianBlur(inData);
	}

	float[,] CreateGaussianKernel(int size, float sigma)
	{
		float[,] kernel = new float[size, size];
		int offset = size / 2;
		float sum = 0;

		for (int i = -offset; i <= offset; i++)
		{
			for (int j = -offset; j <= offset; j++)
			{
				float value = Mathf.Exp(-(i * i + j * j) / (2 * sigma * sigma));
				kernel[i + offset, j + offset] = value;
				sum += value;
			}
		}

		// Normalize the kernel
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				kernel[i, j] /= sum;
			}
		}

		return kernel;
	}
}
