using UnityEngine;

public class PipelineStack : TerrainPipelineComponent
{
    [SerializeField] TerrainPipelineComponent[] _stack;

	public override void CreateData(int mapXSize, int mapZSize, float maxMapHeight)
	{
		foreach (var component in _stack)
		{
			component.CreateData(mapXSize, mapZSize, maxMapHeight);
		}
	}

	public override float[,] ManipulateData(float[,] inData)
	{
		foreach (var component in _stack)
		{
			inData = component.ManipulateData(inData);
		}
		return inData;
	}
}
