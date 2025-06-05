using UnityEngine;

public class TerrainPipeline : MonoBehaviour
{
	[SerializeField] TerrainData _data;
	[SerializeField] TerrainPipelineComponent[] pipeline;
	public Vector3 mapSize;

	public void RenderPipeline()
	{
		int mapXSize = _data.heightmapResolution;
		int mapZSize = _data.heightmapResolution;
		float mapYSize = _data.heightmapScale.y;
		mapSize = new Vector3(mapXSize, mapYSize, mapZSize);

		float[,] elevationData = _data.GetHeights(0, 0, mapXSize, mapZSize);

		foreach (var component in pipeline)
		{
			component.CreateData(mapXSize, mapZSize, mapYSize);
			elevationData = component.ManipulateData(elevationData);
		}

		_data.SetHeights(0, 0, elevationData);
	}
}
